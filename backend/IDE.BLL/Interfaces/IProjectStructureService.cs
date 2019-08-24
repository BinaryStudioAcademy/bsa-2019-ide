using IDE.Common.ModelsDTO.DTO.Workspace;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IProjectStructureService
    {
        Task<ProjectStructureDTO> GetByIdAsync(string id);
        Task UpdateAsync(ProjectStructureDTO projectStructureDTO);
        Task<ProjectStructureDTO> CreateAsync(ProjectStructureDTO projectStructureDto);
        Task<ProjectStructureDTO> CreateEmptyAsync(int projectId, string projectName);
        Task UnzipProject(ProjectStructureDTO projectStructure, IFormFile zipFile, int userId, int projectId);
    }
}
