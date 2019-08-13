using IDE.Common.DTO.Common;
using IDE.Common.DTO.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectInfoDTO> GetProjectById(int projectId);
        Task<ICollection<ProjectDescriptionDTO>> GetAssignedUserProjects(int userId);
        Task<ICollection<ProjectDescriptionDTO>> GetFavoriteUserProjects(int userId);
        Task<ICollection<ProjectDescriptionDTO>> GetAllProjects(int userId);
        Task<ICollection<ProjectDescriptionDTO>> GetUserProjects(int userId);
        Task<int> CreateProject(ProjectCreateDTO project);
        Task UpdateProject(ProjectEditDTO project, int id);       
        Task<ProjectDTO> GetProjectByIdAsync(int projectId);
        Task DeleteProjectAsync(int id);
    }
}
