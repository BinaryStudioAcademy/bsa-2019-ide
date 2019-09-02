using IDE.Common.DTO.Common;
using IDE.Common.ModelsDTO.DTO.Common;
using RabbitMQ.Shared.ModelsDTO.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IBuildService
    {
        Task BuildProject(int projectId, ProjectLanguageType languageType);
        Task<IEnumerable<BuildDescriptionDTO>> GetBuildsByProjectId(int userId);
        Task RunProject(int projectId, string userIdentifier);
    }
}
