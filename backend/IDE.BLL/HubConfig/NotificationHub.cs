﻿using IDE.BLL.Interfaces;
using IDE.DAL.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace IDE.BLL.HubConfig
{
    [Authorize]
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
            var projectMembers = await _context.ProjectMembers
                .Where(item => item.UserId == userId)
                .ToListAsync().ConfigureAwait(false);

            var userProjects = await _context.Projects
                .Where(item => item.AuthorId == userId)
                .ToListAsync().ConfigureAwait(false);

            foreach (var member in projectMembers)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, member.ProjectId.ToString()).ConfigureAwait(false);
            }

            foreach(var userProject in userProjects)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userProject.Id.ToString()).ConfigureAwait(false);
            }
        }

        public void Join(int userId)
        {
            Clients.Client(Context.ConnectionId)
                .SendAsync("sendConnectionId", Context.ConnectionId, userId)
                .ConfigureAwait(false);
        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public async Task MarkAsRead(int notificationId)
        {
            await _notificationService.MarkAsRead(notificationId).ConfigureAwait(false);
        }
    }
}
