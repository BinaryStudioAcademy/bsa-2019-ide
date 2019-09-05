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
using IDE.DAL.Entities;
using IDE.Common.DTO.User;
using IDE.Common.Enums;

namespace IDE.BLL.Services
{
    public class BuildService : IBuildService
    {
        private readonly IProjectStructureService _projectStructureService;
        private readonly IBlobRepository _blobRepo;
        private readonly IQueueService _queueService;
        private readonly IdeContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly INotificationService notificationService;

        public BuildService(
            IProjectStructureService projectStructureService,
            IBlobRepository blobRepo,
            IQueueService queueService,
            ITokenService tokenService,
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
            _tokenService = tokenService;
        }
        
        public async Task BuildProject(int projectId, int userId, ProjectLanguageType languageType)
        {
            var archive = await _projectStructureService.CreateProjectZipFile(projectId);
            var uri = await _blobRepo.UploadProjectArchiveAsync(archive, $"project_{projectId}");
            var build = await CreateStartBuildArtifacts(projectId, userId);
            var message = new ProjectForBuildDTO()
            {
                ProjectId = projectId,
                UriForProjectDownload = uri,
                Language = languageType,
                TimeStamp = DateTime.Now,
                BuildId = build.Id
            };
            var strMessage = JsonConvert.SerializeObject(message);
            _queueService.SendBuildMessage(strMessage);
        }

        public async Task<Build> CreateStartBuildArtifacts(int projectId,int userId)
        {
            var buildDTO = new BuildDTO();

            buildDTO.BuildStarted = DateTime.Now;
            buildDTO.UserId = userId;
            buildDTO.ProjectId = projectId;

            var build = _mapper.Map<Build>(buildDTO);

            var coutOfExistBuild = _context.Builds
                .Where(item => item.ProjectId == projectId)
                .Count();

            var project = await _context.Projects
                .FirstOrDefaultAsync(item => item.Id == projectId);

            if(coutOfExistBuild == project.CountOfSaveBuilds)
            {
                var olderBuild = await _context.Builds
                .Where(item => item.ProjectId == build.ProjectId)
                .OrderBy(item=>item.BuildStarted)
                .FirstOrDefaultAsync();

                _context.Remove(olderBuild);
            }

            await _context.Builds.AddAsync(build);
            await _context.SaveChangesAsync();
            return build;
        }

        public async Task<BuildDTO> CreateFinishBuildArtifacts(BuildResultDTO result)
        {
            var build = await _context.Builds
                .FirstOrDefaultAsync(item => item.Id == result.BuildId);
            build.BuildFinished = DateTime.Now;
            if(result.WasBuildSucceeded)
            {
                build.BuildStatus = BuildStatus.Successfull;
                build.BuildMessage = string.IsNullOrWhiteSpace(result.Message) ? "Build finished successfully" : result.Message;
            }
            else
            {
                build.BuildStatus = BuildStatus.Failed;
                build.BuildMessage = "Build failed with message: "+ result.Message;
            }
            _context.Builds.Update(build);
            await _context.SaveChangesAsync();
            return _mapper.Map<BuildDTO>(build);
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

        public async Task RunProject(int projectId, string connectionId, params string[] inputs)
        {
            var archive = await _projectStructureService.CreateProjectZipFile(projectId);
            var uri = await _blobRepo.UploadProjectArchiveAsync(archive, $"project_{projectId}");
            var message = new ProjectForRunDTO()
            {
                ProjectId = projectId,
                UriForProjectDownload = uri,
                ConnectionId = connectionId,
                TimeStamp = DateTime.Now,
                Inputs=inputs
            };

            var strMessage = JsonConvert.SerializeObject(message);
            _queueService.SendRunMessage(strMessage);
        }
    }
}