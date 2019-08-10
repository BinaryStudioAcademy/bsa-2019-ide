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
    public class FileService
    {
        private readonly INoSqlRepository<File> _repository;
        private readonly IMapper _mapper;

        public FileService(INoSqlRepository<File> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<FileDTO>> GetAllAsync()
        {
            var files = await _repository.GetAllAsync();

            return _mapper.Map<ICollection<FileDTO>>(files);
        }

        public async Task<FileDTO> GetByIdAsync(string id)
        {
            var file = await _repository.GetByIdAsync(id);
            if (file == null)
                throw new NotFoundException(nameof(File), id);

            return _mapper.Map<FileDTO>(file);
        }

        public async Task<FileDTO> CreateAsync(FileDTO item)
        {
            var createdItem = _mapper.Map<File>(item);
            createdItem.CreatedAt = DateTime.Now;
            var file = await _repository.CreateAsync(createdItem);

            return _mapper.Map<FileDTO>(file);
        }

        public async Task UpdateAsync(FileDTO item)
        {
            var updatedItem = _mapper.Map<File>(item);

            await _repository.UpdateAsync(updatedItem);
        }

        public async Task DeleteAsync(string id)
        {
            var file = await _repository.GetByIdAsync(id);
            if (file == null)
                throw new NotFoundException(nameof(File), id);

            await _repository.DeleteAsync(id);
        }
    }
}
