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

        public async Task SendNotificationToUser(int userId, NotificationDTO notificationDTO)
        {
            var notification = _mapper.Map<Notification>(notificationDTO);
            await _hubContext.Clients.User(userId.ToString())
                    .SendAsync("transferchartdata", notificationDTO)
                    .ConfigureAwait(false);
        }
        public async Task SendNotificationToProjectParticipants(int projectId, NotificationDTO notificationDTO)
        {
            var users = await _context.ProjectMembers
                .Where(item => item.ProjectId == projectId)
                .Select(item => item.User)
                .ToListAsync() ?? new List<User>();

            var author = await _context.Projects
                .Where(item => item.Id == projectId)
                .Select(item => item.Author)
                .FirstOrDefaultAsync();

            if (author != null)
                users.Add(author);
            
            foreach (var user in users)
            {
                var notification = _mapper.Map<Notification>(notificationDTO);
                user.Notifications.Add(notification);
                _context.Update(user);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                var notificationToSend = _mapper.Map<NotificationDTO>(notification);

                await _hubContext.Clients.User(user.Id.ToString())
                    .SendAsync("transferchartdata", notificationToSend)
                    .ConfigureAwait(false);
            }                
        }

        public async Task SendNotificationToSpecificConnection(NotificationDTO notification, string connectionId)
        {
            await _hubContext.Clients.Client(connectionId)
                .SendAsync("transferRunResult", notification)
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

            return _mapper.Map<NotificationDTO>(notification);
        }
    }
}
