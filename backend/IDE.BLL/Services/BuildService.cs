using IDE.BLL.Interfaces;
using Storage.Interfaces;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class BuildService : IBuildService
    {
        private readonly IProjectStructureService _projectStructureService;
        private readonly IBlobRepository _blobRepo;
        private readonly IQueueService _queueService;

        public BuildService(
            IProjectStructureService projectStructureService,
            IBlobRepository blobRepo,
            IQueueService queueService)
        {
            _projectStructureService = projectStructureService;
            _blobRepo = blobRepo;
            _queueService = queueService;
        }

        public async Task BuildDotNetProject(int projectId)
        {
            var archive = await _projectStructureService.CreateProjectZipFile(projectId);
            var uri = await _blobRepo.UploadAsync(archive, projectId, 1);
            _queueService.SendMessage($"project_{projectId}_for_build_{1}", projectId);
        }
    }
}