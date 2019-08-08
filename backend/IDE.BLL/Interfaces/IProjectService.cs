using IDE.Common.DTO.Project;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDescriptionDTO>> GetAssignedUserProjects(int userId);
        Task<IEnumerable<ProjectDescriptionDTO>> GetAllProjects(int userId);
        Task<IEnumerable<ProjectDescriptionDTO>> GetUserProjects(int userId);
    }
}
