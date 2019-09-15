using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Common;
using IDE.Common.DTO.Project;
using IDE.Common.DTO.User;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.Common.ModelsDTO.DTO.Project;
using IDE.Common.ModelsDTO.DTO.User;
using IDE.Common.ModelsDTO.Enums;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RabbitMQ.Shared.ModelsDTO.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IdeContext _context;
        private readonly IMapper _mapper;
        private readonly FileService _fileService;
        private readonly ILogger<ProjectService> _logger;
        private readonly INotificationService _notificationService;
        private readonly IQueueService _queueService;
        private readonly IBuildService _buildService;
        private readonly UserService _userService;
        private readonly IEditorSettingService _editorSettingService;

        public ProjectService(IdeContext context,
            IMapper mapper,
            FileService fileService,
            UserService userService,
            INotificationService notificationService,
            ILogger<ProjectService> logger,
            IQueueService queueService,
            IEditorSettingService editorSettingService,
            IBuildService buildService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
            _notificationService = notificationService;
            _logger = logger;
            _editorSettingService = editorSettingService;
            _userService = userService;
            _queueService = queueService;
            _buildService = buildService;
        }

        public async Task BuildProject(int projectId, int userId)
        {
            var project = await GetProjectById(projectId);
            if (project.Language == Language.CSharp && project.ProjectType == ProjectType.Console)
                await _buildService.BuildProject(projectId, userId, ProjectLanguageType.CSharpConsoleApp);
            else if (project.Language == Language.Go)
                await _buildService.BuildProject(projectId, userId, ProjectLanguageType.GoConsoleApp);
            else if (project.Language == Language.TypeScript)
                await _buildService.BuildProject(projectId, userId, ProjectLanguageType.TypeScriptConsoleApp);
        }

        public async Task<IEnumerable<string>> GetInputElements(int projectId)
        {
            var result = new List<string>();
            var projectFiles = await _fileService.GetAllForProjectAsync(projectId);
            string inputStart = "Console.ReadLine()";
            foreach (var file in projectFiles)
            {
                var content = file.Content;
                while (content.Contains(inputStart))
                {
                    var indexOdReadLine = content.IndexOf(inputStart);
                    var substring = content.Substring(0, indexOdReadLine);
                    var posision1 = substring.LastIndexOf(";") + 1;
                    var posision2 = substring.LastIndexOf("{") + 1;
                    var posision = posision1 > posision2 ? posision1 : posision2;
                    substring = substring.Substring(posision);
                    string variable = "";
                    var eaqual = substring.LastIndexOf("=") - 1;
                    while (substring[eaqual] == ' ')
                    {
                        eaqual--;
                    }
                    int index = eaqual;
                    while (substring[index] != ' ')
                    {
                        variable = substring[index] + variable;
                        index--;
                    }
                    result.Add(variable);
                    var newContent = content.Remove(posision, substring.Length + inputStart.Length + 1);
                    content = newContent;
                }
            }
            return result;
        }

        public async Task RunProject(int projectId, string connectiondId, params string[] inputs)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == projectId);
            if (project == null)
                return;
            if (project.Language == Language.CSharp)
                await _buildService.RunProject(projectId, connectiondId, inputs);
        }

        // TODO: understand what type to use ProjectDescriptionDTO or ProjectDTO
        public async Task<ProjectDTO> GetProjectByIdAsync(int projectId)
        {
            var project = await _context.Projects
                .Include(p => p.Author)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task<ICollection<SearchProjectDTO>> GetProjectsName(int userId)
        {
            var availableProjects = _context.Projects
            .Where(pr => pr.AccessModifier == AccessModifier.Public
                    || pr.AuthorId == userId
                    || pr.ProjectMembers.Any(prM => prM.UserId == userId))
            .Select(item => new SearchProjectDTO { Id = item.Id, Name = item.Name }).ToListAsync();

            return await availableProjects;
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetAssignedUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.ProjectMembers
                .Where(pr => pr.UserId == userId)
                .Include(x => x.Project)
                .Select(x => x.Project)
                .Include(x => x.Author)
                .Include(x => x.ProjectMembers);

            var collection = await projects.ToListAsync();

            return MapAndGetLastBuildFinishedDate(collection, userId);
        }

        public async Task<ICollection<CollaboratorDTO>> GetProjectCollaborators(int projectId, int authorId)
        {
            var colaborators = await _context.ProjectMembers
                .Where(a => a.ProjectId == projectId && a.UserId != authorId)
                .Select(a => new CollaboratorDTO
                {
                    Id = a.UserId,
                    NickName = a.User.NickName,
                    Access = a.UserAccess
                }).ToListAsync();

            return colaborators;
        }

        public async Task<ICollection<ProjectUserPageDTO>> GetProjectsByUserId(int userId)
        {
            var projects = _context.Projects
               .Where(pr => pr.AuthorId == userId && pr.AccessModifier!=AccessModifier.Private)
               .Select(x => new ProjectUserPageDTO
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description
               });

            var collection = await projects.ToListAsync();

            return collection;
        }

        public async Task<ICollection<ProjectUserPageDTO>> GetAssignedProjectsByUserId(int userId)
        {
            var projects = _context.ProjectMembers
              .Where(pr => pr.UserId == userId)
              .Include(x => x.Project)
              .Select(x => new ProjectUserPageDTO
              {
                  Id=x.Project.Id,
                  Name=x.Project.Name,
                  Description=x.Project.Description,
                  UserAccess = x.UserAccess
              });

            var collection = await projects.ToListAsync();

            return _mapper.Map<ICollection<ProjectUserPageDTO>>(collection);
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.Projects
                .Where(pr => pr.AuthorId == userId)
                .Include(x => x.Author)
               .Include(x => x.ProjectMembers);

            var collection = await projects.ToListAsync();

            return MapAndGetLastBuildFinishedDate(collection, userId);
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetFavouriteUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.FavouriteProjects
               .Where(pr => pr.UserId == userId)
               .Include(x => x.Project)
               .Select(x => x.Project)
               .Include(x => x.Author)
               .Include(x => x.ProjectMembers);


            var collection = await projects.ToListAsync();

            return MapAndGetLastBuildFinishedDate(collection, userId);
        }

        private ICollection<ProjectDescriptionDTO> MapAndGetLastBuildFinishedDate(List<Project> projects, int userId)
        {
            var projectsDescriptions = _mapper.Map<ICollection<ProjectDescriptionDTO>>(projects);

            var likedProject = _context.FavouriteProjects.Where(x => x.UserId == userId);
            foreach (var projectDescription in projectsDescriptions)
            {
                var build = _context.Builds
                    .Where(y => y.ProjectId == projectDescription.Id)
                    .OrderByDescending(z => z.BuildFinished)
                    .FirstOrDefault();
                projectDescription.LastBuild = build?.BuildFinished;
                projectDescription.BuildStatus = build?.BuildStatus;

                projectDescription.Favourite = likedProject.FirstOrDefault(x => x.ProjectId == projectDescription.Id) != null;
            }

            return projectsDescriptions.OrderByDescending(x => x.LastBuild).ToList();
        }

        public async Task<int> CreateProject(ProjectCreateDTO projectCreateDto, int userId)
        {
            var project = _mapper.Map<Project>(projectCreateDto);
            var user = await _userService.GetUserDetailsById(userId);
            project.AuthorId = userId;
            project.CreatedAt = DateTime.Now;
            project.AccessModifier = projectCreateDto.Access;
            var userEditorSettings = (await _userService.GetUserDetailsById(userId)).EditorSettings;
            var newProjectEditorSetting = new EditorSettingDTO
            {
                CursorStyle = userEditorSettings.CursorStyle,
                FontSize = userEditorSettings.FontSize,
                ScrollBeyondLastLine = userEditorSettings.ScrollBeyondLastLine,
                RoundedSelection = userEditorSettings.RoundedSelection,
                TabSize = userEditorSettings.TabSize,
                LineHeight = userEditorSettings.LineHeight,
                LineNumbers = userEditorSettings.LineNumbers,
                ReadOnly = userEditorSettings.ReadOnly,
                Theme = userEditorSettings.Theme,
                Language = (projectCreateDto.Language.ToString()).ToLower()
            };
            var createDTO = await _editorSettingService.CreateEditorSettings(newProjectEditorSetting);
            project.EditorProjectSettingsId = _mapper.Map<EditorSetting>(createDTO).Id;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"project created {project.Name}");
            return project.Id;
        }

        public async Task<ProjectInfoDTO> GetProjectById(int projectId)
        {
            var project = await _context.Projects
                .Include(x => x.Author)
                .Include(i => i.EditorProjectSettings)
                .Include(g => g.GitCredential)
                .Include(p => p.ProjectMembers)
                .SingleOrDefaultAsync(p => p.Id == projectId);

            return _mapper.Map<ProjectInfoDTO>(project);
        }

        public async Task<ProjectInfoDTO> UpdateProject(ProjectUpdateDTO projectUpdateDTO)
        {
            var targetProject = await _context.Projects.SingleOrDefaultAsync(p => p.Id == projectUpdateDTO.Id);

            if (targetProject == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"update project not found");
                throw new NotFoundException(nameof(targetProject), projectUpdateDTO.Id);
            }

            targetProject.Name = projectUpdateDTO.Name;
            targetProject.Description = projectUpdateDTO.Description;
            targetProject.CountOfBuildAttempts = projectUpdateDTO.CountOfBuildAttempts;
            targetProject.CountOfSaveBuilds = projectUpdateDTO.CountOfSaveBuilds;
            targetProject.AccessModifier = projectUpdateDTO.AccessModifier;
            targetProject.Color = projectUpdateDTO.Color;

            _context.Projects.Update(targetProject);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"project updated {projectUpdateDTO.Id}");
            return await GetProjectById(projectUpdateDTO.Id);
        }

        public async Task<int> GetAuthorId(int projectId)
        {
            var author = await _context.Projects.FirstOrDefaultAsync(item => item.Id == projectId);
            return author.AuthorId;
        }

        public async Task DeleteProjectAsync(int id, int ownerId)
        {

            var project = await _context.Projects
                .Include(pr => pr.Builds)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"delete project not found");
                throw new NotFoundException(nameof(Project), id);
            }
            if (project.AuthorId != ownerId)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"not author delete project");
                throw new InvalidAuthorException();
            }

            //var filesDelete = await _fileService.GetAllForProjectAsync(id);
            //foreach (var file in filesDelete)
            //{
            //    await _fileService.DeleteAsync(file.Id);
            //}

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"project deleted {project.Id}");
        }

        public async Task<IEnumerable<LikedProjectDTO>> GetLikedProjects()
        {
            var likedProjects = await _context.FavouriteProjects
                .Include(x => x.Project)
                .Include(x => x.Project.Author)
                .Where(x => x.Project.AccessModifier != AccessModifier.Private)
                .GroupBy(x => x.ProjectId)
                    .Select(z => new LikedProjectDTO()
                    {
                        ProjectId = z.FirstOrDefault().ProjectId,
                        ProjectDescription = z.FirstOrDefault().Project.Description,
                        ProjectName = z.FirstOrDefault().Project.Name,
                        AuthorNickName = z.FirstOrDefault().Project.Author.NickName,
                        LikesCount = z.Count(),
                    }).OrderByDescending(i => i.LikesCount).Take(6).ToListAsync();
            return await SetLastFileChangedDate(likedProjects);
        }

        private async Task<IEnumerable<LikedProjectDTO>> SetLastFileChangedDate(IEnumerable<LikedProjectDTO> likedProjects)
        {
            foreach (var project in likedProjects)
            {
                var projectFiles = await _fileService.GetAllForProjectAsync(project.ProjectId);
                project.LastChangedDate = projectFiles.OrderByDescending(x => x.UpdatedAt).FirstOrDefault()?.UpdatedAt;
            }
            return likedProjects;
        }

        public async Task<IFormFile> ConvertFilestreamToIFormFile(Stream contentStream, string name, string fileName)
        {
            var ms = new MemoryStream();
            try
            {
                await contentStream.CopyToAsync(ms);
                ms.Seek(0, SeekOrigin.Begin);
                return new FormFile(ms, 0, ms.Length, name, fileName);
            }
            catch (Exception)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"convert stream exception");
                return null;
            }
        }
    }
}
