using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return await this._notificationService.GetNotificationByUserIs(userId);
        }
    }
}