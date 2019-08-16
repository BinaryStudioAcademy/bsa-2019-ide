using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class RightsService : IRightsService
    {
        private IdeContext _context;

        public RightsService(IdeContext context)
        {
            _context = context;
        }

        public ProjectRightsDTO GetUserRightsForProject(int projectId, int userId)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == projectId);
            if (project.AuthorId == userId)
                return new ProjectRightsDTO() { IsAuthor = true };
            
            var projectMember = _context.ProjectMembers.FirstOrDefault(pm => pm.UserId == userId && pm.ProjectId == projectId);
            if (projectMember == null)
            {
                if (project.IsPrivate)
                    return new ProjectRightsDTO();
                else
                    return new ProjectRightsDTO() { Access = UserAccess.CanRead };
            }
            else
            {
                return new ProjectRightsDTO() { Access = projectMember.UserAccess };
            }
        }

        public async Task SetRightsToProject(int projectId, UserAccess access, int userId)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == projectId);
            if (project.AuthorId == userId)
                throw new RightsChangeForProjectAuthorException();

            var projectMember = _context.ProjectMembers.FirstOrDefault(pm => pm.UserId == userId && pm.ProjectId == projectId);
            if (projectMember == null)
            {
                _context.Add(new ProjectMember()
                {
                    ProjectId = projectId,
                    UserId = userId,
                    UserAccess = access
                });
            }
            else
            {
                projectMember.UserAccess = access;
                _context.Update(projectMember);
            }
            await _context.SaveChangesAsync();
        }
    }
}
