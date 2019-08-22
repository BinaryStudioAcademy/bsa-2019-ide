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
    public class NotificationHub: Hub
    {
        public readonly IdeContext _context;

        public NotificationHub(IdeContext context)
        {
            _context = context;
        }
        public async Task JoinGroup(int userId)
        {
            var project = await _context.ProjectMembers
                .Where(item => item.UserId == userId)
                .ToListAsync();
            if (project.Count!=0)
            {
                foreach(var item in project)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, item.ProjectId.ToString());
                }
            }
        }


    }
}
