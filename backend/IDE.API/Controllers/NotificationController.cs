using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("getUserNotification/{userId}")]
        public async Task<IEnumerable<NotificationDTO>> GetNotificationByUserIs(int userId)
        {
            return await _notificationService.GetNotificationByUserId(userId)
                .ConfigureAwait(false);
        }
    }
}