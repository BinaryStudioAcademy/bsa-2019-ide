using IDE.Common.DTO.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<ICollection<ProjectDescriptionDTO>> GetAssignedUserProjects(int userId);
        Task<ICollection<ProjectDescriptionDTO>> GetAllProjects(int userId);
        Task<ICollection<ProjectDescriptionDTO>> GetUserProjects(int userId);
        Task CreateProject(ProjectCreateDTO project);
    }
}
