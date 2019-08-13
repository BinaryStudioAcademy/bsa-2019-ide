using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Common;
using IDE.Common.DTO.Project;
using IDE.Common.Enums;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
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

        public ProjectService(IdeContext context, IMapper mapper, FileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }

        // TODO: understand what type to use ProjectDescriptionDTO or ProjectDTO
        public async Task<ProjectDTO> GetProjectByIdAsync(int projectId)
        {
            var project = await _context.Projects
                .Include(p => p.Author)
                .Include(p => p.Logo)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetAllProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = await _context.Projects
                .Include(x => x.Author)
                .Include(x => x.Logo)
                .ToListAsync();


            return MapAndGetLastBuildFinishedDate(projects, userId);
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetAssignedUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.ProjectMembers
                .Where(pr => pr.UserId == userId)
                .Include(x => x.Project)
                .Select(x => x.Project)
                .Include(x => x.Author)
                .Include(x => x.Logo);
            
            var collection = await projects.ToListAsync();

            return MapAndGetLastBuildFinishedDate(collection, userId);
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.Projects
                .Where(pr => pr.AuthorId == userId)
                .Include(x => x.Author)
                .Include(x => x.Logo);

            var collection = await projects.ToListAsync();

            return MapAndGetLastBuildFinishedDate(collection, userId);
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetFavoriteUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.FavouriteProjects
               .Where(pr => pr.UserId == userId)
               .Include(x => x.Project)
               .Select(x => x.Project)
               .Include(x => x.Author)
               .Include(x => x.Logo);


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

        public async Task<int> CreateProject(ProjectCreateDTO projectCreateDto)
        {
            if (_context.Users.SingleOrDefault(u => u.Id == projectCreateDto.AuthorId) == null)
            {
                throw new InvalidAuthorException();
            }

            var project = _mapper.Map<Project>(projectCreateDto);
            project.CreatedAt = DateTime.Now;
            project.AccessModifier = AccessModifier.Private;

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            //maybe it`s bad code, but i need to get projectId for redirection to project-details dage
            var projectForId = await _context.Projects.LastAsync();
            return projectForId.Id;
        }

        public async Task<ProjectInfoDTO> GetProjectById(int projectId)
        {
            var project = await _context.Projects
                .Include(x => x.Author)
                .SingleOrDefaultAsync(p => p.Id == projectId);

            return _mapper.Map<ProjectInfoDTO>(project);
        }

        public async Task UpdateProject(ProjectEditDTO projectEditDto, int id)
        {
            var targetProject = await _context.Projects.SingleOrDefaultAsync(p => p.Id == id);

            if (targetProject == null)
            {
                throw new NotFoundException(nameof(targetProject), id);
            }

            targetProject.Name = projectEditDto.Name;
            targetProject.Description = projectEditDto.Description;
            targetProject.AccessModifier = projectEditDto.AccessModifier;

            _context.Projects.Update(targetProject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
                throw new NotFoundException(nameof(Project), id);

            var filesDelete = await _fileService.GetAllForProjectAsync(id);
            foreach (var file in filesDelete)
            {
                await _fileService.DeleteAsync(file.Id);
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}