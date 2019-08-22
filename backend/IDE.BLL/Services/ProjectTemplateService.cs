using IDE.BLL.Helpers;
using IDE.BLL.Interfaces;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Workspace;
using IDE.Common.ModelsDTO.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class ProjectTemplateService : IProjectTemplateService
    {
        private readonly FileService _fileService;

        public ProjectTemplateService(FileService fileService)
        {
            _fileService = fileService;
        }
        public async Task<ProjectStructureDTO> GenerateProjectTemplate(string projectName, int projectId, int authorId, Language language)
        {
            switch (language)
            {
                case Language.CSharp:
                    return await GenerateCSharpConsoleTemplate(projectName, projectId, authorId);
                //case Language.TypeScript:
                //    break;
                //case Language.JavaScript:
                //    break;
                //case Language.Go:
                //    break;
                default:
                    return await GenerateCSharpConsoleTemplate(projectName, projectId, authorId);

            }
        }

        private async Task<ProjectStructureDTO> GenerateCSharpConsoleTemplate(string projectName, int projectId, int authorId)
        {
            var projectStructureDTO = new ProjectStructureDTO();
            projectStructureDTO.Id = projectId.ToString();

            var programFile = await _fileService.CreateAsync(new Common.DTO.File.FileCreateDTO()
            {
                Name = "Program.cs",
                Content = "Hello World",//create helper with this code)
                Folder = projectName,
                ProjectId = projectId
            },
            authorId);

            var projectFile = await _fileService.CreateAsync(new Common.DTO.File.FileCreateDTO()
            {
                Name = projectName.Capitalize() + ".csproj",//create helper with this code)
                Content = "Hello World",
                Folder = projectName,
                ProjectId = projectId
            },
            authorId);

            projectStructureDTO.NestedFiles.Add(
                new FileStructureDTO
                {
                    Type = TreeNodeType.Folder,
                    Name = projectName,
                    NestedFiles = new List<FileStructureDTO>()
                        {
                            new FileStructureDTO()
                            {
                                Id = programFile.Id,
                                Name = programFile.Name,
                                Type = TreeNodeType.File,
                                //FilenameExtension = "cs"//maybe better to use enums
                            },
                            new FileStructureDTO()
                            {
                                Id = projectFile.Id,
                                Name = projectFile.Name,
                                Type = TreeNodeType.File,
                                //FilenameExtension = "csproj"//maybe better to use enums
                            }
                        }
                });

            return projectStructureDTO;
        }
    }
}
