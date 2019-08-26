using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.File;
using IDE.Common.ModelsDTO.DTO.Workspace;
using IDE.Common.ModelsDTO.Enums;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using File = System.IO.File;

namespace IDE.BLL.Services
{
    public class ProjectStructureService : IProjectStructureService
    {
        private readonly IProjectStructureRepository _projectStructureRepository;
        private readonly FileService _fileService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectStructureService> _logger;
        private readonly IConfiguration _configuration;

        public ProjectStructureService(
            IProjectStructureRepository projectStructureRepository,
            FileService fileService,
            IMapper mapper, ILogger<ProjectStructureService> logger,
            IConfiguration configuration)
        {
            _projectStructureRepository = projectStructureRepository;
            _fileService = fileService;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<ProjectStructureDTO> GetByIdAsync(string id)
        {
            var projectStructure = await _projectStructureRepository.GetByIdAsync(id);
            if (projectStructure == null)
            {
                throw new NotFoundException(nameof(ProjectStructure), id);
            }

            var projectStructureDto = _mapper.Map<ProjectStructureDTO>(projectStructure);

            return projectStructureDto;
        }

        public async Task<int> GetFileStructureSize(FileStructureDTO projectStructureDTO, string fileStructureId)
        {
            foreach (var item in projectStructureDTO.NestedFiles)
            {
                if (item.Id == fileStructureId)
                {
                    return item.Size;
                }
                int size = await GetFileStructureSize(item, fileStructureId);
                if(size!=0)
                {
                    return size;
                }
            }
            return 0;
        }

        public async Task UpdateAsync(ProjectStructureDTO projectStructureDTO)
        {
            var currentProjectStructureDto = await GetByIdAsync(projectStructureDTO.Id);
            currentProjectStructureDto.NestedFiles = projectStructureDTO.NestedFiles;

            var projectStructureUpdate = _mapper.Map<ProjectStructure>(currentProjectStructureDto);
            await _projectStructureRepository.UpdateAsync(projectStructureUpdate);
        }

        public async Task<ProjectStructureDTO> CreateAsync(ProjectStructureDTO projectStructureDto)
        {
            var projectStructureCreate = _mapper.Map<ProjectStructure>(projectStructureDto);
            var createdProjectStructure = await _projectStructureRepository.CreateAsync(projectStructureCreate);

            return await GetByIdAsync(createdProjectStructure.Id);
        }

        public async Task<ProjectStructureDTO> CreateEmptyAsync(int projectId, string projectName)
        {
            var emptyStructureDTO = new ProjectStructureDTO()
            {
                Id = projectId.ToString()
            };
            var initialFileStructure = new FileStructureDTO()
            {
                Type = TreeNodeType.Folder,
                Id = Guid.NewGuid().ToString(),
                Details = $"Super important details of file {projectName}",
                Name = projectName
            };
            emptyStructureDTO.NestedFiles.Add(initialFileStructure);

            var emptyStructure = _mapper.Map<ProjectStructure>(emptyStructureDTO);
            var createdProjectStructure = await _projectStructureRepository.CreateAsync(emptyStructure);
            return await GetByIdAsync(createdProjectStructure.Id);
        }

        public async Task UnzipProject(ProjectStructureDTO projectStructure, IFormFile zipFile, int userId, int projectId)
        {
            string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "..\\Temp", Guid.NewGuid().ToString());
            try
            {
                if (!Directory.Exists(tempFolder))
                {
                    Directory.CreateDirectory(tempFolder);
                }
                if (zipFile.Length > 0)
                {
                    string fullPathToFile = Path.Combine(tempFolder, zipFile.FileName);
                    using (var stream = new FileStream(fullPathToFile, FileMode.Create))
                    {
                        await zipFile.CopyToAsync(stream).ConfigureAwait(false);
                    }
                    var pathToProject = UnzipProject(fullPathToFile, tempFolder);
                    var rootFileStructure = projectStructure.NestedFiles.FirstOrDefault();

                    await GetFilesRecursive(pathToProject, rootFileStructure, userId, projectId).ConfigureAwait(false);
                    var projectStructureDto = _mapper.Map<ProjectStructureDTO>(projectStructure);
                    await UpdateAsync(projectStructureDto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (Directory.Exists(tempFolder))
                {
                    Directory.Delete(tempFolder, true);
                }
            }
        }

        private async Task GetFilesRecursive(string sourseDir, FileStructureDTO fileStructureRoot, int userId, int projectId)
        {
            try
            {
                foreach (string directory in Directory.GetDirectories(sourseDir))
                {
                    var dirName = directory.Substring(directory.LastIndexOf('\\') + 1);

                    var nestedFileStructure = new FileStructureDTO()
                    {
                        Type = TreeNodeType.Folder,
                        Name = dirName,
                        Id = Guid.NewGuid().ToString()
                    };
                    fileStructureRoot.NestedFiles.Add(nestedFileStructure);
                    await GetFilesRecursive(directory, nestedFileStructure, userId, projectId);
                }
                foreach (var file in Directory.GetFiles(sourseDir))
                {
                    var fileName = file.Substring(file.LastIndexOf('\\') + 1);
                    var dirName = sourseDir.Substring(sourseDir.LastIndexOf('\\') + 1);

                    Debug.WriteLine(dirName);

                    var fileCreateDto = new FileCreateDTO();
                    fileCreateDto.Folder = dirName;
                    fileCreateDto.Name = fileName;
                    fileCreateDto.ProjectId = projectId;
                    fileCreateDto.Content = await GetFileContent(file);

                    var fileCreated = await _fileService.CreateAsync(fileCreateDto, userId);
                    var nestedFileStructure = new FileStructureDTO()
                    {
                        Type = TreeNodeType.File,
                        Name = fileName,
                        Id = fileCreated.Id,
                        Size = Encoding.Unicode.GetByteCount(fileCreated.Content)
                    };
                    fileStructureRoot.NestedFiles.Add(nestedFileStructure);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task<string> GetFileContent(string filepath)
        {
            string text;
            var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = await streamReader.ReadToEndAsync().ConfigureAwait(false);
            }
            return text;
        }
        public  async Task<ProjectStructureDTO> CalculateProjectStructureSize(ProjectStructureDTO projectStructureDTO)
        {
            List<FileStructureDTO> rootfolder = new List<FileStructureDTO>();
            foreach (var item in projectStructureDTO.NestedFiles)
            {
                rootfolder.Add(await CalculateSize(item));
            }
            projectStructureDTO.NestedFiles = rootfolder;
            return projectStructureDTO;
        }

        private string UnzipProject(string pathToArchive, string destinationDirectoryPath)
        {
            ZipFile.ExtractToDirectory(pathToArchive, destinationDirectoryPath);

            var pathToProject = pathToArchive.Substring(0, pathToArchive.LastIndexOf('.'));
            return pathToProject;
        }

        public async Task<byte[]> CreateProjectZipFile(int projectId, string folderGuid = "")
        {
            var tempDir = _configuration.GetSection("TempDir").Value;
            var path = Path.Combine(tempDir, Guid.NewGuid().ToString());
            byte[] emptyAchive;
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                }
                emptyAchive = memoryStream.ToArray();
            }
            try
            {
                var fileStructure = await GetFolderNode(projectId, folderGuid).ConfigureAwait(false);

                if (fileStructure == null || fileStructure.NestedFiles.Count == 0)
                    return emptyAchive;

                var filesId = GetListOfFilesId(fileStructure);
                if (filesId.Count == 0)
                    return emptyAchive;

                var allFileInFileStructure = await _fileService.GetRangeByListOfIdAsync(filesId);

                await SaveFilesOnDisk(fileStructure, allFileInFileStructure, Path.Combine(path, "ProjectFolder")).ConfigureAwait(false);
                ZipFile.CreateFromDirectory(Path.Combine(path, "ProjectFolder"), Path.Combine(path, $"{projectId}.zip"));

                var fileByteArray = await File.ReadAllBytesAsync(Path.Combine(path, $"{projectId}.zip")).ConfigureAwait(false);
                return fileByteArray;
            }
            catch (Exception exception)
            {
                _logger.LogWarning(exception, exception.Message);
                throw exception;
            }
            finally
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
        }

        private async Task SaveFilesOnDisk(FileStructureDTO fileStructure, IDictionary<string, FileDTO> allFileInFileStructure, string path)
        {
            foreach (var node in fileStructure.NestedFiles)
            {
                if (node.Type == TreeNodeType.File)
                {

                    var hasFile = allFileInFileStructure.TryGetValue(node.Id, out var file);
                    if (!hasFile)
                        continue;

                    Directory.CreateDirectory(path);
                    using (StreamWriter streamWriter = File.CreateText(Path.Combine(path, file.Name)))
                    {
                        await streamWriter.WriteAsync(file.Content).ConfigureAwait(false);
                    }
                }
                else
                {
                    await SaveFilesOnDisk(node, allFileInFileStructure, Path.Combine(path, node.Name)).ConfigureAwait(false);
                }
            }
        }

        private ICollection<string> GetListOfFilesId(FileStructureDTO fileStructure)
        {
            var filesId = new List<string>();

            var queue = new Queue<FileStructureDTO>(fileStructure.NestedFiles);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.Type == TreeNodeType.File)
                {
                    filesId.Add(node.Id);
                    continue;
                }
                foreach (var subFolder in node.NestedFiles)
                {
                     queue.Enqueue(subFolder);
                }
            }
            return filesId;
        }

        private async Task<FileStructureDTO> GetFolderNode(int projectId, string folderGuid)
        {
            var projectStructure = await GetByIdAsync(projectId.ToString()).ConfigureAwait(false);

            if (string.IsNullOrEmpty(folderGuid))
                return projectStructure.NestedFiles.FirstOrDefault();

            var queue = new Queue<FileStructureDTO>(projectStructure.NestedFiles);

            while (queue.Count > 0)
            {
                var folder = queue.Dequeue();

                if (folder.Id == folderGuid)
                    return folder;

                foreach (var subFolder in folder.NestedFiles)
                {
                    if (subFolder.Type == TreeNodeType.Folder)
                        queue.Enqueue(subFolder);
                }
            }
            return null;
        }

        private async Task<FileStructureDTO> CalculateSize(FileStructureDTO projectStructureDTO)
        {
            foreach (var item in projectStructureDTO.NestedFiles)
            {
                if (item.Type == 0)
                {
                    item.Size = (await CalculateSize(item)).Size;
                }
                else
                {
                    item.Size = await _fileService.GetFileSize(item.Id);
                }
                projectStructureDTO.Size += item.Size;
            }

            return projectStructureDTO;
        }
    }
}
