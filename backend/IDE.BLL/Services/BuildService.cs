using AutoMapper;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Common;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.DAL.Context;
using IDE.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RabbitMQ.Shared.ModelsDTO;
using Storage.Interfaces;
using System.Threading.Tasks;
using System;
using RabbitMQ.Shared.ModelsDTO.Enums;

namespace IDE.BLL.Services
{
    public class BuildService : IBuildService
    {
        private readonly IProjectStructureService _projectStructureService;
        private readonly IBlobRepository _blobRepo;
        private readonly IQueueService _queueService;
        private readonly IdeContext _context;
        private readonly IMapper _mapper;
        private readonly INotificationService notificationService;

        public BuildService(
            IProjectStructureService projectStructureService,
            IBlobRepository blobRepo,
            IQueueService queueService,
            IdeContext context,
            IMapper mapper,
            INotificationService notificationService)
        {
            _projectStructureService = projectStructureService;
            _blobRepo = blobRepo;
            _queueService = queueService;
            _context = context;
            _mapper = mapper;
            this.notificationService = notificationService;
        }

        public async Task BuildProject(int projectId, ProjectLanguageType languageType)
        {
            var archive = await _projectStructureService.CreateProjectZipFile(projectId);
            var uri = await _blobRepo.UploadProjectArchiveAsync(archive, $"project_{projectId}");
            var message = new ProjectForBuildDTO()
            {
                ProjectId = projectId,
                UriForProjectDownload = uri,
                Language = languageType,
                TimeStamp = DateTime.Now
            };
            var strMessage = JsonConvert.SerializeObject(message);
            _queueService.SendBuildMessage(strMessage);
        }

        public async Task<IEnumerable<BuildDescriptionDTO>> GetBuildsByProjectId(int projectId)
        {
            var builds = await _context.Builds
                .Where(item => item.ProjectId == projectId)
                .Include(item => item.Project)
                .Include(item => item.User)
                .Select(item => _mapper.Map<BuildDescriptionDTO>(item))
                .ToListAsync();

            return builds;
        }

        public async Task RunProject(int projectId, string connectionId)
        {
            var archive = await _projectStructureService.CreateProjectZipFile(projectId);
            var uri = await _blobRepo.UploadProjectArchiveAsync(archive, $"project_{projectId}");
            var message = new ProjectForRunDTO()
            {
                ProjectId = projectId,
                UriForProjectDownload = uri,
                ConnectionId = connectionId,
                TimeStamp = DateTime.Now
            };

            var strMessage = JsonConvert.SerializeObject(message);
            _queueService.SendRunMessage(strMessage);
        }
    }
}