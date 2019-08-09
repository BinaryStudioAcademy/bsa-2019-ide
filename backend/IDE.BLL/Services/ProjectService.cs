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
using System.Text;
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

        public async Task<IEnumerable<ProjectDescriptionDTO>> GetAllProjects(int userId)
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

            return await MapAndGetLastBuildFinishedDate(projects).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProjectDescriptionDTO>> GetAssignedUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.ProjectMembers
                .Where(pr => pr.UserId == userId)
                .Include(x => x.Project)
                .Select(x => x.Project)
                .Include(x => x.Author)
                .Include(x => x.Logo);

            return await MapAndGetLastBuildFinishedDate(await projects.ToListAsync()).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ProjectDescriptionDTO>> GetUserProjects(int userId)
        {
            //Maybe it can be a bit easier
            var projects = _context.Projects
                .Where(pr => pr.AuthorId == userId)
                .Include(x => x.Author)
                .Include(x => x.Logo);
            
            return await MapAndGetLastBuildFinishedDate(await projects.ToListAsync()).ConfigureAwait(false);
        }

        private async Task<IEnumerable<ProjectDescriptionDTO>> MapAndGetLastBuildFinishedDate(List<Project> projects)
        {
            var projectsDescriptions = _mapper.Map<IEnumerable<ProjectDescriptionDTO>>(projects);

            projectsDescriptions
                .ToList()
                .ForEach(
                    x => x.LastBuild = _context.Builds
                                                .Where(y => y.ProjectId == x.Id)
                                                .OrderByDescending(z => z.BuildFinished)
                                                .FirstOrDefault()
                                                ?.BuildFinished);
            return projectsDescriptions;
        }

        public async Task CreateProject(ProjectCreateDTO projectCreateDTO)
        {

            if (_context.Users.SingleOrDefault(u => u.Id == projectCreateDTO.AuthorId) == null)
            {
                throw new InvalidAuthorException();
            }

            var project = _mapper.Map<Project>(projectCreateDTO);
            project.CreatedAt = DateTime.Now;

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }
    }
}
