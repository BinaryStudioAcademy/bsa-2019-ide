using AutoMapper;
using IDE.BLL.HubConfig;
using IDE.BLL.Interfaces;
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
        public NotificationService(IHubContext<NotificationHub> hubContext,
            IdeContext context,
            IMapper mapper)
        {
            _hubContext = hubContext;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificationDTO>> GetNotificationsByUserId(int userId)
        {
            var notifications = await _context.Notifications
                .Where(item => item.UserId == userId)
                .ToListAsync();
            return notifications != null ? _mapper.Map<List<NotificationDTO>>(notifications) : null;
        }

        public async Task<NotificationDTO> SendNotification(int projectId, NotificationDTO notificationDTO)
        {
            var notification = _mapper.Map<Notification>(notificationDTO);
            await _context.Notifications
                .AddAsync(notification);

            await _context.SaveChangesAsync();
            if (notification != null)
            {
                await _hubContext.Clients.Groups(projectId.ToString()).SendAsync("transferchartdata", notificationDTO);
                return _mapper.Map<NotificationDTO>(notification);
            }

            return null;
        }

        public async Task DeleteNotificationAsync(int identifier)
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(item => item.Id == identifier);
            _context.Remove(notification);
            await _context.SaveChangesAsync();
        }
    }
}
