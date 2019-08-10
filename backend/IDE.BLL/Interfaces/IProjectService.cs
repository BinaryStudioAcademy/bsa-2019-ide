using IDE.Common.DTO.Common;
using IDE.Common.DTO.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDescriptionDTO>> GetAssignedUserProjects(int userId);
        Task<IEnumerable<ProjectDescriptionDTO>> GetAllProjects(int userId);
        Task<IEnumerable<ProjectDescriptionDTO>> GetUserProjects(int userId);
        Task CreateProject(ProjectCreateDTO project);
        Task<ProjectDTO> GetProjectByIdAsync(int projectId);
    }
}
