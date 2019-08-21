using IDE.BLL.HubConfig;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SentNotification(string userId, string message)
        {
            await _hubContext.Clients.All.SendAsync("transferchartdata", message);
        }
    }
}
