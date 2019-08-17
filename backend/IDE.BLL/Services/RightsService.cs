using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.Common.ModelsDTO.DTO.User;
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
                if (project.AccessModifier == AccessModifier.Private)
                    return new ProjectRightsDTO();
                else
                    return new ProjectRightsDTO() { Access = UserAccess.CanRead };
            }
            else
            {
                return new ProjectRightsDTO() { Access = projectMember.UserAccess };
            }
        }

        public async Task SetRightsToProject(UpdateUserRightDTO update)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == update.ProjectId);
            if (project.AuthorId == update.UserId)
                throw new RightsChangeForProjectAuthorException();

            var projectMember = _context.ProjectMembers.FirstOrDefault(pm => pm.UserId == update.UserId && pm.ProjectId == update.ProjectId);
            if (projectMember == null)
            {
                _context.Add(new ProjectMember()
                {
                    ProjectId = update.ProjectId,
                    UserId = update.UserId,
                    UserAccess = update.Access
                });
            }
            else
            {
                projectMember.UserAccess = update.Access;
                _context.Update(projectMember);
            }
            await _context.SaveChangesAsync();
        }
    }
}
