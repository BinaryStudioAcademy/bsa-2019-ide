using AutoMapper;
using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Project;
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

        public ProjectService(IdeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetAllProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = await _context.ProjectMembers
                .Where(pr => pr.UserId == userId)
                .Include(x => x.Project)
                .Select(x => x.Project)
                .Include(x => x.Author)
                .Include(x => x.Logo)
                .ToListAsync();

            projects
                .AddRange(await _context.Projects
                    .Where(pr => pr.AuthorId == userId)
                    .Include(x => x.Author)
                    .Include(x => x.Logo)
                    .ToListAsync());

            return MapAndGetLastBuildFinishedDate(projects);
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

            return MapAndGetLastBuildFinishedDate(collection);
        }

        public async Task<ICollection<ProjectDescriptionDTO>> GetUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.Projects
                .Where(pr => pr.AuthorId == userId)
                .Include(x => x.Author)
                .Include(x => x.Logo);

            var collection = await projects.ToListAsync();

            return MapAndGetLastBuildFinishedDate(collection);
        }

        private ICollection<ProjectDescriptionDTO> MapAndGetLastBuildFinishedDate(List<Project> projects)
        {
            var projectsDescriptions = _mapper.Map<ICollection<ProjectDescriptionDTO>>(projects);

            foreach (var projectDescription in projectsDescriptions)
            {
                projectDescription.LastBuild = _context.Builds
                    .Where(y => y.ProjectId == projectDescription.Id)
                    .OrderByDescending(z => z.BuildFinished)
                    .FirstOrDefault()?.BuildFinished;
            }

            return projectsDescriptions;
        }

        public async Task CreateProject(ProjectCreateDTO projectCreateDto)
        {
            if (_context.Users.SingleOrDefault(u => u.Id == projectCreateDto.AuthorId) == null)
            {
                throw new InvalidAuthorException();
            }

            var project = _mapper.Map<Project>(projectCreateDto);
            project.CreatedAt = DateTime.Now;

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }
    }
}