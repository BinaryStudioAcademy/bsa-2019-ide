using IDE.BLL.ExceptionsCustom;
using IDE.BLL.Interfaces;
using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.Common.ModelsDTO.DTO.User;
using IDE.Common.ModelsDTO.Enums;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<RightsService> _logger;
        private IServiceScopeFactory _serviceScopeFactory;


        public RightsService(IdeContext context, ILogger<RightsService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _context = context;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
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

        public async Task DeleteRights(int collaboratorId, int projectId, int currentUserId)
        {
            var project = await _context.Projects.Where(item => item.Id == projectId).FirstOrDefaultAsync();

            if (project.AuthorId == currentUserId)
            {
                var collaborator = await _context.ProjectMembers
                    .Where(item => item.UserId == collaboratorId && item.ProjectId == projectId)
                    .FirstOrDefaultAsync();
                _context.ProjectMembers.Remove(collaborator);
                await _context.SaveChangesAsync();
            }
            else
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"NonAuthorRightsChange");
                throw new NonAuthorRightsChange();
            }

            var notification = new NotificationDTO()
            {
                Type = NotificationType.AssinedToProject,
                ProjectId = projectId,
                DateTime = DateTime.Now,
                Message = $"You was deleted from project \"{project.Name}\".",
                Status = NotificationStatus.Message
            };

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                await notificationService.SendNotificationToUserById(collaboratorId, notification);
            }
        }

        public async Task SetRightsToProject(UpdateUserRightDTO update, int userId)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == update.ProjectId);
            if (project.AuthorId != userId)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"NonAuthorRightsChange");
                throw new NonAuthorRightsChange();
            }
            if (project.AuthorId == update.UserId)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"RightsChangeForProjectAuthorException");
                throw new RightsChangeForProjectAuthorException();
            }

            var projectMember = await _context.ProjectMembers
                .FirstOrDefaultAsync(pm => pm.UserId == update.UserId && pm.ProjectId == update.ProjectId);
            if (projectMember == null)
            {
                await _context.AddAsync(new ProjectMember()
                    {
                        ProjectId = update.ProjectId,
                        UserId = update.UserId,
                        UserAccess = update.Access
                    }
                );
            }
            else
            {
                projectMember.UserAccess = update.Access;
                _context.Update(projectMember);
            }
            await _context.SaveChangesAsync();

            var opportunity = string.Empty;
            switch (update.Access)
            {
                case UserAccess.CanRead:
                    opportunity = "can read";
                    break;
                case UserAccess.CanWrite:
                    opportunity = "can write";
                    break;
                case UserAccess.CanBuild:
                    opportunity = "can build";
                    break;
                case UserAccess.CanRun:
                    opportunity = "can run";
                    break;
                default:
                    opportunity = string.Empty;
                    break;
            }

            var notification = new NotificationDTO()
            {
                Type = NotificationType.AssinedToProject,
                ProjectId = update.ProjectId,
                DateTime = DateTime.Now,
                Message = $"Now you can {opportunity} project \"{project.Name}\".",
                Status = NotificationStatus.Message
            };

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var notificationService = scope.ServiceProvider.GetService<INotificationService>();
                await notificationService.SendNotificationToUserById(update.UserId, notification); 
            }
        }
    }
}
