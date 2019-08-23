using IDE.BLL.Interfaces;
using IDE.DAL.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.HubConfig
{
    public class NotificationHub : Hub
    {
        public readonly IdeContext _context;
        public readonly INotificationService _notificationService;

        public NotificationHub(IdeContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }
        public async Task JoinGroup(int userId)
        {
            var project = await _context.ProjectMembers
                .Where(item => item.UserId == userId)
                .ToListAsync();
            var userProjects = await _context.Projects
                .Where(item => item.AuthorId == userId)
                .ToListAsync();
            foreach (var item in project)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, item.ProjectId.ToString());
            }

            foreach(var item in userProjects)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, item.Id.ToString());
            }
        }

        public async Task MarkRead(int notificationId)
        {
            await this._notificationService.MarkRead(notificationId);
        }


    }
}
