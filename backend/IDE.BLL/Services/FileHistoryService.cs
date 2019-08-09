using AutoMapper;
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
            var files = await _repository.GetAllAsync();

            return _mapper.Map<ICollection<FileHistoryDTO>>(files);
        }

        public async Task<FileHistoryDTO> GetByIdAsync(string id)
        {
            var file = await _repository.GetByIdAsync(id);

            return _mapper.Map<FileHistoryDTO>(file);
        }

        public async Task<FileHistoryDTO> CreateAsync(FileHistoryDTO item)
        {
            var createdItem = _mapper.Map<FileHistory>(item);
            createdItem.CreatedAt = DateTime.Now;
            var file = await _repository.CreateAsync(createdItem);

            return _mapper.Map<FileHistoryDTO>(file);
        }

        public async Task UpdateAsync(FileHistoryDTO item)
        {
            var updatedItem = _mapper.Map<FileHistory>(item);
            updatedItem.UpdatedAt = DateTime.Now;

            await _repository.UpdateAsync(updatedItem);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
