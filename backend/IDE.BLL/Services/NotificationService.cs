using AutoMapper;
using IDE.BLL.HubConfig;
using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class NotificationService : INotificationService
    {

        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IdeContext _context;
        private readonly IMapper _mapper;
        public NotificationService(IHubContext<NotificationHub> hubContext,
            IdeContext context,
            IMapper mapper)
        {
            _hubContext = hubContext;
            _context = context;
            _mapper = mapper;
        }
        public async Task SendNotification(int projectId, NotificationDTO notificationDTO)
        {
            var users = await _context.ProjectMembers
                .Where(item => item.ProjectId == projectId)
                .Select(item => item.User)
                .ToListAsync().ConfigureAwait(false);

            var author = await _context.Projects
                .Where(item => item.Id == projectId)
               .Select(item => item.Author)
              .FirstOrDefaultAsync().ConfigureAwait(false);

            users.Add(author);

            var notification = _mapper.Map<Notification>(notificationDTO);

            foreach (var user in users)
            {
                // BUG: Ovveriding uderId in notification
                user.Notifications.Add(notification);
                _context.Update(user);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }

            notificationDTO = _mapper.Map<NotificationDTO>(notification);
            await _hubContext.Clients.Groups(projectId.ToString())
                .SendAsync("transferchartdata", notificationDTO)
                .ConfigureAwait(false);

        }

        public async Task<IEnumerable<NotificationDTO>> GetNotificationByUserId(int userId)
        {
            var notifications = await _context.Notifications
                .Where(notification => !notification.IsRead && notification.UserId == userId)
                .Select(item => _mapper.Map<NotificationDTO>(item))
                .ToListAsync().ConfigureAwait(false);            

            return notifications;
        }

        public async Task MarkAsRead(int notificationId)
        {
            var notification = await _context.Notifications
                .FirstOrDefaultAsync(n => n.Id == notificationId)
                .ConfigureAwait(false);

            notification.IsRead = true;
            _context.Update(notification);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        private async Task<NotificationDTO> CreateNotificationByUser(NotificationDTO notificationDTO)
        {
            var notification = _mapper.Map<Notification>(notificationDTO);
            await _context.Notifications
                .AddAsync(notification)
                .ConfigureAwait(false);

            await _context.SaveChangesAsync()
                .ConfigureAwait(false);

            return _mapper.Map<NotificationDTO>(notification); ;
        }
    }
}
