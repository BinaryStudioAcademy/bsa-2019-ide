using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Workspace;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IProjectTemplateService
    {
        Task<ProjectStructureDTO> GenerateProjectTemplate(string projectName, int projectId, int authorId, Language language);
    }
}
