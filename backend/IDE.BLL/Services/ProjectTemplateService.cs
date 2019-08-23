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
                case Language.TypeScript:
                    return await GenerateTypeScriptConsoleTemplate(projectName, projectId, authorId);
                case Language.JavaScript:
                    return await GenerateJavaScriptConsoleTemplate(projectName, projectId, authorId);
                case Language.Go:
                    return await GenerateGoConsoleTemplate(projectName, projectId, authorId);
                default:
                    throw new ExceptionsCustom.NotFoundException("invalid project language");
            }
        }

        private async Task<ProjectStructureDTO> GenerateCSharpConsoleTemplate(string projectName, int projectId, int authorId)
        {
            var projectStructureDTO = new ProjectStructureDTO();
            projectStructureDTO.Id = projectId.ToString();

            var programFile = await _fileService.CreateAsync(new Common.DTO.File.FileCreateDTO()
            {
                Name = "Program.cs",
                Content = TemplateHelper.CSharpProgramTemplate(projectName.Capitalize()),
                Folder = projectName,
                ProjectId = projectId
                //FilenameExtension = "cs"//maybe better to use enums
            },
            authorId); ;

            var projectFile = await _fileService.CreateAsync(new Common.DTO.File.FileCreateDTO()
            {
                Name = projectName.Capitalize() + ".csproj",//create helper with this code)
                Content = TemplateHelper.CSharpCsprojTemplate(),
                Folder = projectName,
                ProjectId = projectId
                //FilenameExtension = "csproj"//maybe better to use enums
            },
            authorId); ;

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
                            },
                            new FileStructureDTO()
                            {
                                Id = projectFile.Id,
                                Name = projectFile.Name,
                                Type = TreeNodeType.File,
                            }
                        }
                });

            return projectStructureDTO;
        }

        private async Task<ProjectStructureDTO> GenerateGoConsoleTemplate(string projectName, int projectId, int authorId)
        {
            var projectStructureDTO = new ProjectStructureDTO();
            projectStructureDTO.Id = projectId.ToString();

            var programFile = await _fileService.CreateAsync(new Common.DTO.File.FileCreateDTO()
            {
                Name = "main.go",
                Content = TemplateHelper.GoProgramTemplate(),
                Folder = projectName,
                ProjectId = projectId
                //FilenameExtension = "go"//maybe better to use enums
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
                            }
                        }
                });

            return projectStructureDTO;
        }

        private async Task<ProjectStructureDTO> GenerateJavaScriptConsoleTemplate(string projectName, int projectId, int authorId)
        {
            var projectStructureDTO = new ProjectStructureDTO();
            projectStructureDTO.Id = projectId.ToString();

            var programFile = await _fileService.CreateAsync(new Common.DTO.File.FileCreateDTO()
            {
                Name = "main.js",
                Content = TemplateHelper.JsProgramTemplate(),
                Folder = projectName,
                ProjectId = projectId
                //FilenameExtension = "js"//maybe better to use enums
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
                            }
                        }
                });

            return projectStructureDTO;
        }

        private async Task<ProjectStructureDTO> GenerateTypeScriptConsoleTemplate(string projectName, int projectId, int authorId)
        {
            var projectStructureDTO = new ProjectStructureDTO();
            projectStructureDTO.Id = projectId.ToString();

            var programFile = await _fileService.CreateAsync(new Common.DTO.File.FileCreateDTO()
            {
                Name = "main.ts",
                Content = TemplateHelper.JsProgramTemplate(),
                Folder = projectName,
                ProjectId = projectId
                //FilenameExtension = "ts"//maybe better to use enums
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
                            }
                        }
                });

            return projectStructureDTO;
        }   

    }
}
