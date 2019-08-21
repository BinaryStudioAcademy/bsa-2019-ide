using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.HubConfig
{
    public class NotificationHub: Hub
    {
        public async Task Send(string userId)
        {
            var user = Context.User;
            var userName = user.Identity.Name;
            await Clients.Caller.SendAsync("transferchartdata", userId);
        }
    }
}
