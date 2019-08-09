using AutoMapper;
using IDE.Common.DTO.File;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
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

            return _mapper.Map<FileDTO>(file);
        }

        public async Task<FileDTO> CreateAsync(FileDTO item)
        {
            var createdItem = _mapper.Map<File>(item);
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
            await _repository.DeleteAsync(id);
        }
    }
}
