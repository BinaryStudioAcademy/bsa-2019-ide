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

        //public async Task SentNotification(int projectId, string message)
        //{
        //    var groupMembers = _context.ProjectMembers
        //        .Where(item => item.ProjectId == projectId)
        //        .ToListAsync();
        //    await _hubContext.Groups.AddToGroupAsync(, projectId.ToString());
        //    //_hubContext.Clients.Group(roomName).addChatMessage(_hubContext.User.Identity.Name + " joined.");
            
        //}

        public async Task<IEnumerable<NotificationDTO>> GetNotificationsByUserId(int userId)
        {
            var notifications = await _context.Notifications
                .Where(item => item.UserId == userId)
                .ToListAsync();
            return notifications != null ? _mapper.Map<List<NotificationDTO>>(notifications) : null;
        }

        public async Task SendNotification(NotificationDTO notificationDTO)
        {
            var notification = await _context.Notifications
                .AddAsync(_mapper.Map<Notification>(notificationDTO));

            await _context.SaveChangesAsync();
            if (notification != null)
            {
                await _hubContext.Clients.All.SendAsync("transferchartdata", notificationDTO.Message);
            }
        }
    }
}
