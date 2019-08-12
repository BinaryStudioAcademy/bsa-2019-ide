﻿using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.Common.DTO.File;
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
        private readonly INoSqlRepository<FileHistory> _fileHistoryRepository;
        private readonly INoSqlRepository<File> _fileRepository;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public FileHistoryService(
            INoSqlRepository<FileHistory> fileHistoryRepository,
            INoSqlRepository<File> fileRepository,
            UserService userService,
            IMapper mapper)
        {
            _fileHistoryRepository = fileHistoryRepository;
            _userService = userService;
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<FileHistoryDTO>> GetAllForFileAsync(string fileId)
        {
            var file = await _fileRepository.GetByIdAsync(fileId);
            if (file == null)
            {
                throw new NotFoundException(nameof(File), fileId);
            }

            var fileHistories = await _fileHistoryRepository.GetAllAsync();
            var fileHistoriesForFile = fileHistories.Where(fh => fh.FileId == file.Id);

            return _mapper.Map<ICollection<FileHistoryDTO>>(fileHistoriesForFile);
        }

        public async Task<FileHistoryDTO> GetByIdAsync(string id)
        {
            var fileHistory = await _fileHistoryRepository.GetByIdAsync(id);            
            if (fileHistory == null)
            {
                throw new NotFoundException(nameof(FileHistory), id);
            }

            return _mapper.Map<FileHistoryDTO>(fileHistory);
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
                throw new NotFoundException(nameof(FileHistory), id);
            }

            await _fileHistoryRepository.DeleteAsync(id);
        }
    }
}