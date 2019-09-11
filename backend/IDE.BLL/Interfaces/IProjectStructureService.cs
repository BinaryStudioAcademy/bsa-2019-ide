using IDE.Common.ModelsDTO.DTO.Workspace;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IProjectStructureService
    {
        Task<ProjectStructureDTO> GetByIdAsync(string id);
        Task UpdateAsync(ProjectStructureDTO projectStructureDTO);
        Task<ProjectStructureDTO> CreateAsync(ProjectStructureDTO projectStructureDto);
        Task<ProjectStructureDTO> CreateEmptyAsync(int projectId, string projectName);
        //Task UnzipProject(ProjectStructureDTO projectStructure, IFormFile zipFile, int userId, int projectId);
        Task ImportProject(string projectStructureId, IFormFile zipFile, string fileStructureId, int userId, bool partial, string ids);
        Task UpdateProjectStructureFromTempFolder(string projectStructureId, string tempFolder, int userId, bool isClone);
        Task RemoveFilesBeforeCloneAsync(int projectId);
        Task<byte[]> CreateProjectZipFile(int projectId, string folderGuid = "");
        Task ProjectStructureForGit(string projectStructureId, string tempFolder);
        Task UnzipGitFileAsync(MemoryStream memoryStream, string pathToFile, string fileName);
        void ZipGitFileAsync(string pathToFile, string projectId);
        void DeleteTempFolder(string path);
    }
}
