using IDE.Common.DTO.Common;
using IDE.Common.DTO.Project;
using IDE.Common.ModelsDTO.DTO.Project;
using IDE.Common.ModelsDTO.DTO.User;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectInfoDTO> GetProjectById(int projectId);
        Task<ICollection<SearchProjectDTO>> GetProjectsName();
        Task<ICollection<ProjectDescriptionDTO>> GetAssignedUserProjects(int userId);
        Task<ICollection<ProjectDescriptionDTO>> GetFavouriteUserProjects(int userId);
        Task<ICollection<CollaboratorDTO>> GetProjectCollaborators(int projectId, int authorId);
        Task<ICollection<ProjectDescriptionDTO>> GetUserProjects(int userId);
        Task<ICollection<ProjectUserPageDTO>> GetProjectsByUserId(int userId);
        Task<ICollection<ProjectUserPageDTO>> GetAssignedProjectsByUserId(int userId);
        Task<ProjectInfoDTO> UpdateProject(ProjectUpdateDTO project);
        Task<int> GetAuthorId(int projectId);
        Task<int> CreateProject(ProjectCreateDTO project, int userId);
        Task<ProjectDTO> GetProjectByIdAsync(int projectId);
        Task DeleteProjectAsync(int id, int userId);
        Task<IEnumerable<LikedProjectDTO>> GetLikedProjects();
        Task BuildProject(int projectId);
        Task RunProject(int projectId, string connectionId);
        Task<IFormFile> ConvertFilestreamToIFormFile(Stream fileStream, string name, string fileName);
    }
}
