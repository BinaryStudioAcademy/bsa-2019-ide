using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.Common.DTO.File;
using IDE.Common.ModelsDTO.Enums;
using IDE.Common.ModelsDTO.DTO.File;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace IDE.BLL.Services
{
    public class FileService
    {
        private readonly INoSqlRepository<File> _fileRepository;
        private readonly FileHistoryService _fileHistoryService;
        private readonly UserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<FileService> _logger;
        public FileService(
            INoSqlRepository<File> fileRepository, 
            FileHistoryService fileHistoryService, 
            UserService userService,
            IMapper mapper,
            ILogger<FileService> logger)
        {
            _fileRepository = fileRepository;
            _fileHistoryService = fileHistoryService;
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
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
            var filesForProject = await _fileRepository.GetAllAsync(f => listOfId.Any( id => id == f.Id));

            var fileForProjectDtos = _mapper.Map<ICollection<FileDTO>>(filesForProject)
                .ToDictionary(key => key.Id, value => value);

            return fileForProjectDtos;
        }

        public async Task<FileDTO> GetByIdAsync(string id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
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
            var file = await this.GetByIdAsync(id);
            return file.Content.Length;
        }

        public async Task<FileDTO> CreateAsync(FileCreateDTO fileCreateDto, int creatorId)
        {
            var fileCreate = _mapper.Map<File>(fileCreateDto);
            fileCreate.CreatedAt = DateTime.Now;
            fileCreate.CreatorId = creatorId;
            var createdFile = await _fileRepository.CreateAsync(fileCreate);

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
            var currentFileDto = await GetByIdAsync(fileUpdateDTO.Id);
            currentFileDto.Name = fileUpdateDTO.Name;
            currentFileDto.Folder = fileUpdateDTO.Folder;
            currentFileDto.Content = fileUpdateDTO.Content;
            currentFileDto.UpdaterId = updaterId;
            currentFileDto.UpdatedAt = DateTime.Now;

            var fileUpdate = _mapper.Map<File>(currentFileDto);
            await _fileRepository.UpdateAsync(fileUpdate);
                                 
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
        }

        private async Task AddToFileLinkedItems(FileDTO file)
        {
            file.Creator = await _userService.GetUserById(file.CreatorId);
            file.Updater = file.UpdaterId.HasValue ? await _userService.GetUserById(file.UpdaterId.Value) : null;
        }
    }
}
