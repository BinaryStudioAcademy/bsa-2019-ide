using IDE.Common.DTO.Common;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.DAL.Entities;
using RabbitMQ.Shared.ModelsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IBuildService
    {
        Task BuildDotNetProject(int projectId, int userId);
        Task<IEnumerable<BuildDescriptionDTO>> GetBuildsByProjectId(int userId);
        Task RunDotNetProject(int projectId, string userIdentifier);
        Task<BuildDTO> CreateFinishBuildArtifacts(BuildResultDTO result);
    }
}
