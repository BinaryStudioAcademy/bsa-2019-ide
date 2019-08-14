using IDE.Common.ModelsDTO.DTO.Workspace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IProjectStructureService
    {
        Task<ProjectStructureDTO> GetByIdAsync(string id);
        Task UpdateAsync(ProjectStructureDTO projectStructureDTO);
        Task<ProjectStructureDTO> CreateAsync(ProjectStructureDTO projectStructureDto);
        Task<ProjectStructureDTO> CreateEmpty(string projectId);
    }
}
