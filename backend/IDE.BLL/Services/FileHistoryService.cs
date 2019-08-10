using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.Common.DTO.File;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class FileHistoryService
    {
        private readonly INoSqlRepository<FileHistory> _repository;
        private readonly IMapper _mapper;

        public FileHistoryService(INoSqlRepository<FileHistory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<FileHistoryDTO>> GetAllAsync()
        {
            var fileHistories = await _repository.GetAllAsync();

            return _mapper.Map<ICollection<FileHistoryDTO>>(fileHistories);
        }

        public async Task<FileHistoryDTO> GetByIdAsync(string id)
        {
            var fileHistory = await _repository.GetByIdAsync(id);            
            if (fileHistory == null)
            {
                throw new NotFoundException(nameof(FileHistory), id);
            }

            return _mapper.Map<FileHistoryDTO>(fileHistory);
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
