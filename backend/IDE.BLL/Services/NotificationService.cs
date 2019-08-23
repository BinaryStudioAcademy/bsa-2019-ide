using AutoMapper;
using IDE.BLL.HubConfig;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.User;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
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
        private readonly ITokenService _tokenSevice;
        public NotificationService(IHubContext<NotificationHub> hubContext,
            IdeContext context,
            IMapper mapper,
            ITokenService tokenService)
        {
            _hubContext = hubContext;
            _context = context;
            _mapper = mapper;
            _tokenSevice = tokenService;
        }
        public async Task SendNotification(int projectId, NotificationDTO notificationDTO)
        {
            var users = await _context.ProjectMembers
                .Where(item => item.ProjectId == projectId)
                .Select(item => item.User)
                .ToListAsync();

            var author = await _context.Projects
                .Where(item => item.Id == projectId)
               .Select(item => item.Author)
              .FirstOrDefaultAsync();

            users.Add(author);

            Notification notification = _mapper.Map<Notification>(notificationDTO);

            foreach (var item in users)
            {
                item.Notifications.Add(notification);
            }

            notificationDTO = _mapper.Map<NotificationDTO>(notification);
            await _hubContext.Clients.Groups(projectId.ToString()).SendAsync("transferchartdata", notificationDTO);

        }

        public async Task<IEnumerable<NotificationDTO>> GetNotificationByUserIs(int userId)
        {
            var user = await _context.Users
                .Where(item => item.Id == userId)
                .FirstOrDefaultAsync();
            var notifications = user.Notifications
                .Where(item => item.IsRead == false)
                .Select(item => _mapper.Map<NotificationDTO>(item))
                .ToList();

            return notifications;
        }

        public async Task MarkRead(int notificationId)
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(item => item.Id == notificationId);
            notification.IsRead = true;
            _context.Update(notification);
            await _context.SaveChangesAsync();
        }

        private async Task<NotificationDTO> CreateNotificationByUser(NotificationDTO notificationDTO)
        {
            var notification = _mapper.Map<Notification>(notificationDTO);
            await _context.Notifications
                .AddAsync(notification);

            await _context.SaveChangesAsync();

            return _mapper.Map<NotificationDTO>(notification); ;
        }
    }
}
