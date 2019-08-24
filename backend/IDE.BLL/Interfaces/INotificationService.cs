﻿using IDE.Common.ModelsDTO.DTO.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface INotificationService
    {
        Task SendNotification(int projectId, NotificationDTO notificationDTO);
        Task MarkAsRead(int notificationId);
        Task<IEnumerable<NotificationDTO>> GetNotificationByUserId(int userId);
    }
}