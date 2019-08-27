using AutoMapper;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Common;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.DAL.Context;
using IDE.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class BuildService : IBuildService
    {
        private readonly IProjectStructureService _projectStructureService;
        private readonly IBlobRepository _blobRepo;
        private readonly IQueueService _queueService;
        private readonly IdeContext _context;
        private readonly IMapper _mapper;

        public BuildService(
            IProjectStructureService projectStructureService,
            IBlobRepository blobRepo,
            IQueueService queueService,
            IdeContext context,
            IMapper mapper)
        {
            _projectStructureService = projectStructureService;
            _blobRepo = blobRepo;
            _queueService = queueService;
            _context = context;
            _mapper = mapper;
        }

        public async Task BuildDotNetProject(int projectId)
        {
            var archive = await _projectStructureService.CreateProjectZipFile(projectId);
            var uri = await _blobRepo.UploadAsync(archive, projectId, 1);
            _queueService.SendMessage($"project_{projectId}_for_build_{1}", projectId);
        }

        public async Task<IEnumerable<BuildDescriptionDTO>> GetBuildsByUserId(int userId)
        {
            var builds = await _context.Builds
                .Where(item => item.UserId == userId)
                .Include(item=>item.Project)
                .Include(item => item.User)
                .Select(item=>_mapper.Map<BuildDescriptionDTO>(item))
                .ToListAsync();

            return builds;
        }
    }
}