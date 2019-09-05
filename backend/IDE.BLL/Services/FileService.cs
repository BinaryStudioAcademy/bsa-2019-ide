using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.Common.DTO.File;
using IDE.Common.ModelsDTO.DTO.File;
using IDE.Common.ModelsDTO.Enums;
using IDE.DAL.Entities.Elastic;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using IDE.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class FileService
    {
        private readonly INoSqlRepository<File> _fileRepository;
        private readonly FileSearchRepository _fileSearchRepository;
        private readonly FileHistoryService _fileHistoryService;
        private readonly UserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<FileService> _logger;
        private readonly int _maxFilesInProjectCount;
        private readonly int _maxFileSize;

        public FileService(
            INoSqlRepository<File> fileRepository,
            FileSearchRepository fileSearchRepository,
            FileHistoryService fileHistoryService, 
            UserService userService,
            IMapper mapper,
            ILogger<FileService> logger,
            ConfigurationService configuration)
        {
            _fileRepository = fileRepository;
            _fileSearchRepository = fileSearchRepository;
            _fileHistoryService = fileHistoryService;
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
            _maxFilesInProjectCount = configuration.MaxFilesInProjectCount;
            _maxFileSize = configuration.MaxFileSize;
        }

        public async Task<ICollection<FileDTO>> GetAllForProjectAsync(int projectId)
        {
            var filesForProject = await _fileRepository.GetAllAsync(f => f.ProjectId == projectId);

            var fileForProjectDtos = _mapper.Map<ICollection<FileDTO>>(filesForProject);
            foreach (var fileForProjectDto in fileForProjectDtos)
            {
                await AddToFileLinkedItems(fileForProjectDto);
            }

            return fileForProjectDtos;
        }
        public async Task<IDictionary<string, FileDTO>> GetRangeByListOfIdAsync(ICollection<string> listOfId)
        {
            var filesForProject = new List<File>();
            foreach(var id in listOfId)
            {
                var file = await _fileRepository.GetByIdAsync(id).ConfigureAwait(false);
                if (file != null)
                    filesForProject.Add(file);
            }

            var fileForProjectDtos = _mapper.Map<ICollection<FileDTO>>(filesForProject)
                .ToDictionary(key => key.Id, value => value);

            return fileForProjectDtos;
        }

        public async Task<FileDTO> GetByIdAsync(string id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            //file.IsOpen = true;
            if (file == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, $"GetFileById({id}) NOT FOUND");
                throw new NotFoundException(nameof(File), id);
            }

            var fileDto = _mapper.Map<FileDTO>(file);
            await AddToFileLinkedItems(fileDto);

            return fileDto;
        }

        public async Task<int> GetFileSize(string id)
        {
            var file = await GetByIdAsync(id);
            return file.Content.Length;
        }
        private int GetStringSize(string str)
        {
            return str.Length;
        }

        public async Task<FileDTO> CreateAsync(FileCreateDTO fileCreateDto, int creatorId)
        {
            if((await _fileRepository.GetItemsCount()) > _maxFilesInProjectCount)
            {
                throw new TooManyFilesInProjectException(_maxFilesInProjectCount);
            }
            if(GetStringSize(fileCreateDto.Content) > _maxFileSize)
            {
                throw new TooHeavyFileException(_maxFileSize);
            }

            var fileCreate = _mapper.Map<File>(fileCreateDto);
            fileCreate.CreatedAt = DateTime.Now;
            fileCreate.UpdatedAt = DateTime.Now;
            fileCreate.CreatorId = creatorId;
            fileCreate.IsOpen = false;

            var index = fileCreate.Name.IndexOf('.') + 1;
            var name = fileCreate.Name;
            var expantion = name.Substring(index, name.Length- index);
            fileCreate.Language= GetFileLanguage(expantion);
            var createdFile = await _fileRepository.CreateAsync(fileCreate);

            var searchFile = _mapper.Map<FileSearch>(createdFile);
            await _fileSearchRepository.IndexAsync(searchFile);

            var fileHistory = new FileHistoryDTO
            {
                FileId = createdFile.Id,
                Name = createdFile.Name,
                Folder = createdFile.Folder,
                Content = createdFile.Content,
                CreatorId = creatorId,
                CreatedAt = createdFile.CreatedAt
            };
            await _fileHistoryService.CreateAsync(fileHistory);

            return await GetByIdAsync(createdFile.Id);
        }

        public async Task UpdateAsync(FileUpdateDTO fileUpdateDTO, int updaterId)
        {
            if (GetStringSize(fileUpdateDTO.Content) > _maxFileSize)
            {
                throw new TooHeavyFileException(_maxFileSize);
            }

            var currentFileDto = await GetByIdAsync(fileUpdateDTO.Id);
            currentFileDto.Name = fileUpdateDTO.Name;
            currentFileDto.Folder = fileUpdateDTO.Folder;
            currentFileDto.Content = fileUpdateDTO.Content;
            currentFileDto.UpdaterId = updaterId;
            currentFileDto.UpdatedAt = DateTime.Now;
            currentFileDto.IsOpen = fileUpdateDTO.IsOpen;

            var fileUpdate = _mapper.Map<File>(currentFileDto);
            await _fileRepository.UpdateAsync(fileUpdate);

            var searchFile = _mapper.Map<FileSearch>(fileUpdate);
            await _fileSearchRepository.UpdateAsync(searchFile);

            var fileHistory = new FileHistoryDTO
            {
                FileId = fileUpdateDTO.Id,
                Name = fileUpdateDTO.Name,
                Folder = fileUpdateDTO.Folder,
                Content = fileUpdateDTO.Content,
                CreatorId = updaterId,
                CreatedAt = currentFileDto.UpdatedAt.Value
            };
            await _fileHistoryService.CreateAsync(fileHistory);           
        }

        public async Task RenameAsync(FileRenameDTO fileRenameDTO, int updaterId)
        {
            var currentFileDto = await GetByIdAsync(fileRenameDTO.Id);
            currentFileDto.Name = fileRenameDTO.Name;
            currentFileDto.UpdaterId = updaterId;
            currentFileDto.UpdatedAt = DateTime.Now;
            currentFileDto.Language= GetFileLanguage(fileRenameDTO.Name);

            var fileUpdate = _mapper.Map<File>(currentFileDto);
            await _fileRepository.UpdateAsync(fileUpdate);

            var fileHistory = new FileHistoryDTO
            {
                FileId = fileRenameDTO.Id,
                Name = fileRenameDTO.Name,
                CreatorId = updaterId,
                CreatedAt = currentFileDto.UpdatedAt.Value
            };
            await _fileHistoryService.CreateAsync(fileHistory);
        }

        public async Task DeleteAsync(string id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            if (file == null)
            {
                _logger.LogWarning(LoggingEvents.DeleteItemNotFound, $"Deleting file ({id}) NOT FOUND");
                throw new NotFoundException(nameof(File), id);
            }

            var fileHistories = await _fileHistoryService.GetAllForFileAsync(id);
            foreach (var fileHistory in fileHistories)
            {
                await _fileHistoryService.DeleteAsync(fileHistory.Id);
            }

            await _fileRepository.DeleteAsync(id);

            await _fileSearchRepository.DeleteAsync(id);
        }

        private async Task AddToFileLinkedItems(FileDTO file)
        {
            file.Creator = await _userService.GetUserById(file.CreatorId);
            file.Updater = file.UpdaterId.HasValue ? await _userService.GetUserById(file.UpdaterId.Value) : null;
        }

        private string  GetFileLanguage(string name)
        {
            switch (name)
            {
                case "js":
                    return "javascript";
                case "ts":
                    return "typescript";
                case "cs":
                    return "csharp";
                case "html":
                    return "html";
                case "go":
                    return "go";
                case "css":
                    return "css";
            }
            return "";
        }
    }
}
