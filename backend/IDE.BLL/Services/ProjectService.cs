using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Common;
using IDE.Common.DTO.Project;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.Common.ModelsDTO.DTO.Project;
using IDE.Common.ModelsDTO.DTO.User;
using IDE.Common.ModelsDTO.Enums;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        public ProjectService(IdeContext context,
            IMapper mapper,
            FileService fileService,
            INotificationService notificationService,
            ILogger<ProjectService> logger,
            IQueueService queueService,
            IBuildService buildService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
            _notificationService = notificationService;
            _logger = logger;
            _queueService = queueService;
            _buildService = buildService;
        }

        public async Task BuildProject(int projectId)
        {
            var project = await GetProjectById(projectId);
            if (project.Language == Language.CSharp)
                await _buildService.BuildDotNetProject(projectId);
        }


        // TODO: understand what type to use ProjectDescriptionDTO or ProjectDTO
        public async Task<ProjectDTO> GetProjectByIdAsync(int projectId)
        {
            var project = await _context.Projects
                .Include(p => p.Author)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task<ICollection<SearchProjectDTO>> GetProjectsName()
        {
            var project = await _context.Projects
                .Select(item => new SearchProjectDTO { Id = item.Id, Name = item.Name }).ToListAsync();
            return project;
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetAssignedUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.ProjectMembers
                .Where(pr => pr.UserId == userId)
                .Include(x => x.Project)
                .Select(x => x.Project)
                .Include(x => x.Author);

            var collection = await projects.ToListAsync();

            return MapAndGetLastBuildFinishedDate(collection, userId);
        }

        public async Task<ICollection<CollaboratorDTO>> GetProjectCollaborators(int projectId, int authorId)
        {
            var colaborators = await _context.ProjectMembers
                .Where(a => a.ProjectId == projectId && a.UserId != authorId)
                .Select(a => new CollaboratorDTO
                {
                    Id=a.UserId,
                    NickName=a.User.NickName,
                    Access=a.UserAccess
                }).ToListAsync();

            return colaborators;
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.Projects
                .Where(pr => pr.AuthorId == userId)
                .Include(x => x.Author);

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
               .Include(x => x.Author);


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
            project.AuthorId = userId;
            project.CreatedAt = DateTime.Now;
            project.AccessModifier = AccessModifier.Private;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return project.Id;
        }

        public async Task<ProjectInfoDTO> GetProjectById(int projectId)
        {
            var project = await _context.Projects
                .Include(x => x.Author)
                .SingleOrDefaultAsync(p => p.Id == projectId);

            NotificationDTO notification = new NotificationDTO
            {
                Message = $"get project {project.Name}"
            };

            await _notificationService.SendNotification(projectId, notification);

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
        }

        public async Task<IEnumerable<LikedProjectInLanguageDTO>> GetLikedProjects()
        {
            return await _context.FavouriteProjects
                .Include(x => x.Project)
                .Include(x => x.Project.Author)
                .Where(x => x.Project.AccessModifier != AccessModifier.Private)
                .GroupBy(x => x.Project.Language)
                .Select(x =>
                    new LikedProjectInLanguageDTO()
                    {
                        ProjectType = x.Key,
                        LikedProjects =
                                x.GroupBy(y => y.ProjectId)
                                .Select(z => new LikedProjectDTO()
                                {
                                    ProjectId = z.FirstOrDefault().ProjectId,
                                    ProjectDescription = z.FirstOrDefault().Project.Description,
                                    ProjectName = z.FirstOrDefault().Project.Name,
                                    AuthorNickName = z.FirstOrDefault().Project.Author.NickName,
                                    LikesCount = z.Count()
                                }).OrderByDescending(i => i.LikesCount).Take(5).ToArray()
                    })
                    .OrderBy(x => x.ProjectType).ToListAsync();
        }
    }
}
