using IDE.BLL.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Shared.ModelsDTO;
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
            var uri = await _blobRepo.UploadProjectArchiveAsync(archive, $"project_{projectId}");
            var message = new ProjectForBuildDTO()
            {
                ProjectId = projectId,
                UriForProjectDownload = uri
            };
            var strMessage = JsonConvert.SerializeObject(message);
            _queueService.SendMessage(strMessage);
        }
    }
}