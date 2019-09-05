using AutoMapper;
using IDE.BLL.HubConfig;
using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Shared.ModelsDTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IdeContext _context;
        //private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IMapper _mapper;
        public NotificationService(IHubContext<NotificationHub> hubContext,
            IdeContext context,
            //IServiceScopeFactory serviceScopeFactory,
            IMapper mapper, ILogger<NotificationService> logger)
        {
            _hubContext = hubContext;
            _context = context;
            _mapper = mapper;
            _logger = logger;
            //_serviceScopeFactory = serviceScopeFactory;
        }
        public async Task SendNotification(int projectId, NotificationDTO notificationDTO)
        {
            //using (var scope = _serviceScopeFactory.CreateScope())
            //{
            //    var _context = scope.ServiceProvider.GetService<IdeContext>();

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

                var notification = _mapper.Map<Notification>(notificationDTO);

                foreach (var user in users)
                {
                    // BUG: Ovveriding uderId in notification
                    user.Notifications.Add(notification);
                    _context.Update(user);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                _logger.LogInformation("user notification updated");
                notificationDTO = _mapper.Map<NotificationDTO>(notification);
                await _hubContext.Clients.Groups(projectId.ToString())
                    .SendAsync("transferchartdata", notificationDTO)
                    .ConfigureAwait(false);
            //}
        }

        public async Task SendRunResultNotificationToUser(NotificationDTO notification, string connectionId)
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
            _logger.LogInformation("notification marked as read");
        }

        private async Task<NotificationDTO> CreateNotificationByUser(NotificationDTO notificationDTO)
        {
            var notification = _mapper.Map<Notification>(notificationDTO);
            await _context.Notifications
                .AddAsync(notification)
                .ConfigureAwait(false);

            await _context.SaveChangesAsync()
                .ConfigureAwait(false);
            _logger.LogInformation("created notifications");
            return _mapper.Map<NotificationDTO>(notification);
        }
    }
}
