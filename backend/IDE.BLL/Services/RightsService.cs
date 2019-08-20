using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.Common.ModelsDTO.DTO.User;
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
    public class RightsService : IRightsService
    {
        private IdeContext _context;

        public RightsService(IdeContext context)
        {
            _context = context;
        }

        public async Task<ProjectRightsDTO> GetUserRightsForProject(int projectId, int userId)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
            if (project.AuthorId == userId)
                return new ProjectRightsDTO() { IsAuthor = true };
            
            var projectMember = await _context.ProjectMembers.FirstOrDefaultAsync(pm => pm.UserId == userId && pm.ProjectId == projectId);
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

        public async Task<UserAccess> GetUserRightById(int userId, int projectId)
        {
            var access = await _context.ProjectMembers
                .FirstOrDefaultAsync(item => item.UserId == userId && item.ProjectId == projectId);
            return access.UserAccess;
        }

        public async Task DeleteRights(int userId,int projectId, int currentUserId)
        {
            var project = await _context.Projects.Where(item => item.Id == projectId).FirstOrDefaultAsync();

            if (project.AuthorId==currentUserId)
            {
                var collaborator = await _context.ProjectMembers.Where(item => item.UserId == userId && item.ProjectId == projectId).FirstOrDefaultAsync();
                _context.ProjectMembers.Remove(collaborator);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NonAuthorRightsChange();
            }
        }

        public async Task SetRightsToProject(UpdateUserRightDTO update, int userId)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == update.ProjectId);
            if (project.AuthorId != userId)
                throw new NonAuthorRightsChange();
            if (project.AuthorId == update.UserId)
                throw new RightsChangeForProjectAuthorException();

            var projectMember = await _context.ProjectMembers.FirstOrDefaultAsync(pm => pm.UserId == update.UserId && pm.ProjectId == update.ProjectId);
            if (projectMember == null)
            {
                await _context.AddAsync(new ProjectMember()
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
