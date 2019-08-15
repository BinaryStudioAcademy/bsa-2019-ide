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
        Task<ICollection<ProjectDescriptionDTO>> GetFavouriteUserProjects(int userId);
        Task<ICollection<ProjectDescriptionDTO>> GetAllProjects(int userId);
        Task<ICollection<ProjectDescriptionDTO>> GetUserProjects(int userId);
        Task<ProjectInfoDTO> UpdateProject(ProjectUpdateDTO project); 
        Task<int> CreateProject(ProjectCreateDTO project, int userId);
        Task<ProjectDTO> GetProjectByIdAsync(int projectId);
        Task DeleteProjectAsync(int id, int userId);
    }
}
