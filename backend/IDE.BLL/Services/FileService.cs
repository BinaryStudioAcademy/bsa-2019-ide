using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.File;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class FileService
    {
        private readonly INoSqlRepository<File> _fileRepository;
        private readonly FileHistoryService _fileHistoryService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public FileService(INoSqlRepository<File> fileRepository, FileHistoryService fileHistoryService, IProjectService projectService, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _fileHistoryService = fileHistoryService;
            _projectService = projectService;
            _mapper = mapper;
        }

        public async Task<ICollection<FileDTO>> GetAllAsync()
        {
            var files = await _fileRepository.GetAllAsync();

            var fileDtos = _mapper.Map<ICollection<FileDTO>>(files);
            foreach (var fileDto in fileDtos)
            {
                fileDto.Project = await _projectService.GetProjectByIdAsync(fileDto.ProjectId);
                fileDto.FileHistory = await _fileHistoryService.GetByIdAsync(fileDto.FileHistoryId);
            }

            return fileDtos;
        }

        public async Task<FileDTO> GetByIdAsync(string id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            if (file == null)
            {
                throw new NotFoundException(nameof(File), id);
            }

            var fileDto = _mapper.Map<FileDTO>(file);
            fileDto.Project = await _projectService.GetProjectByIdAsync(fileDto.ProjectId);
            fileDto.FileHistory = await _fileHistoryService.GetByIdAsync(fileDto.FileHistoryId);

            return fileDto;
        }

        public async Task<FileDTO> CreateAsync(FileDTO item)
        {
            var createdItem = _mapper.Map<File>(item);
            createdItem.CreatedAt = DateTime.Now;
            var file = await _fileRepository.CreateAsync(createdItem);

            return await GetByIdAsync(file.Id);
        }

        public async Task UpdateAsync(FileDTO item)
        {
            var updatedItem = _mapper.Map<File>(item);

            await _fileRepository.UpdateAsync(updatedItem);
        }

        public async Task DeleteAsync(string id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            if (file == null)
            {
                throw new NotFoundException(nameof(File), id);
            }

            await _fileRepository.DeleteAsync(id);
        }
    }
}
