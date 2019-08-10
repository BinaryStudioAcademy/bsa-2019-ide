using AutoMapper;
using IDE.BLL.ExceptionsCustom;
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
    public class FileHistoryService
    {
        private readonly INoSqlRepository<FileHistory> _repository;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public FileHistoryService(INoSqlRepository<FileHistory> repository, UserService userService, IMapper mapper)
        {
            _repository = repository;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<ICollection<FileHistoryDTO>> GetAllAsync()
        {
            var fileHistories = await _repository.GetAllAsync();

            var fileHistoriesDtos = _mapper.Map<ICollection<FileHistoryDTO>>(fileHistories);
            foreach (var fileHistoriesDto in fileHistoriesDtos)
            {
                fileHistoriesDto.Updater = await _userService.GetUserById(fileHistoriesDto.UpdaterId);
            }
            
            return fileHistoriesDtos;
        }

        public async Task<FileHistoryDTO> GetByIdAsync(string id)
        {
            var fileHistory = await _repository.GetByIdAsync(id);            
            if (fileHistory == null)
            {
                throw new NotFoundException(nameof(FileHistory), id);
            }

            var fileHistoryDto = _mapper.Map<FileHistoryDTO>(fileHistory);
            fileHistoryDto.Updater = await _userService.GetUserById(fileHistoryDto.UpdaterId);

            return fileHistoryDto;
        }

        public async Task<FileHistoryDTO> CreateAsync(FileHistoryDTO item)
        {
            var createdItem = _mapper.Map<FileHistory>(item);
            createdItem.CreatedAt = DateTime.Now;
            var fileHistory = await _repository.CreateAsync(createdItem);

            return _mapper.Map<FileHistoryDTO>(fileHistory);
        }

        public async Task UpdateAsync(FileHistoryDTO item)
        {
            var updatedItem = _mapper.Map<FileHistory>(item);
            updatedItem.UpdatedAt = DateTime.Now;

            await _repository.UpdateAsync(updatedItem);
        }

        public async Task DeleteAsync(string id)
        {
            var fileHistory = await _repository.GetByIdAsync(id);
            if (fileHistory == null)
            {
                throw new NotFoundException(nameof(FileHistory), id);
            }

            await _repository.DeleteAsync(id);
        }
    }
}
