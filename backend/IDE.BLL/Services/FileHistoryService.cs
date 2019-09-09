using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.Common.ModelsDTO.DTO.File;
using IDE.Common.ModelsDTO.Enums;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class FileHistoryService
    {
        private readonly INoSqlRepository<FileHistory> _fileHistoryRepository;
        private readonly INoSqlRepository<File> _fileRepository;
        private readonly UserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<FileHistoryService> _logger;

        public FileHistoryService(
            INoSqlRepository<FileHistory> fileHistoryRepository,
            INoSqlRepository<File> fileRepository,
            UserService userService,
            IMapper mapper, ILogger<FileHistoryService> logger)
        {
            _fileHistoryRepository = fileHistoryRepository;
            _userService = userService;
            _fileRepository = fileRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<FileHistoryDTO>> GetAllForFileAsync(string fileId)
        {
            var file = await _fileRepository.GetByIdAsync(fileId);
            if (file == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"Not found file");
                throw new NotFoundException(nameof(File), fileId);
            }

            var fileHistoriesForFile = await _fileHistoryRepository.GetAllAsync(fh => fh.FileId == file.Id);

            return _mapper.Map<ICollection<FileHistoryDTO>>(fileHistoriesForFile);
        }

        public async Task<FileHistoryDTO> GetByIdAsync(string id)
        {
            var fileHistory = await _fileHistoryRepository.GetByIdAsync(id);            
            if (fileHistory == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"Not found file history");
                throw new NotFoundException(nameof(FileHistory), id);
            }

            return _mapper.Map<FileHistoryDTO>(fileHistory);
        }

        public async Task<FileHistoryDiffContentDTO> GetDiffByIdAsync(string id)
        {
            var fileHistory = await _fileHistoryRepository.GetByIdAsync(id);
            if (fileHistory == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"Not found file history");
                throw new NotFoundException(nameof(FileHistory), id);
            }

            return _mapper.Map<FileHistoryDiffContentDTO>(fileHistory);
        }

        public async Task<IDictionary<string, IEnumerable<FileHistoryDTO>>> GetHistoriesForProject(int projectId)
        {
            var filesForProject = await _fileRepository.GetAllAsync(f => f.ProjectId == projectId);

            var files = new Dictionary<string, IEnumerable<FileHistoryDTO>>();
            
            foreach(var file in filesForProject)
            {
                var fileHistory = (await _fileHistoryRepository.GetAllAsync(fh => fh.FileId == file.Id))
                    .OrderByDescending(fh => fh.ChangedAt)
                    .Select(f => _mapper.Map<FileHistoryDTO>(f))
                    .ToList();
                files.Add($"{file.Id}${file.Name}", fileHistory);
            }

            return files;
        }

        public async Task<FileHistoryDTO> CreateAsync(FileHistoryDTO item)
        {
            var createdItem = _mapper.Map<FileHistory>(item);
            var fileHistory = await _fileHistoryRepository.CreateAsync(createdItem);

            return await GetByIdAsync(fileHistory.Id);
        }

        public async Task DeleteAsync(string id)
        {
            var fileHistory = await _fileHistoryRepository.GetByIdAsync(id);
            if (fileHistory == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"Not found deleting file");
                throw new NotFoundException(nameof(FileHistory), id);
            }

            await _fileHistoryRepository.DeleteAsync(id);
        }
    }
}
