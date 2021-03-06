﻿using IDE.Common.ModelsDTO.DTO.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface INotificationService
    {
        Task MarkAsRead(int notificationId);
        Task<IEnumerable<NotificationDTO>> GetNotificationByUserId(int userId);
        Task SendNotificationToUserById(int userId, NotificationDTO notificationDTO);
        Task SendNotificationToProjectParticipants(int projectId, NotificationDTO notificationDTO);
        Task SendNotificationToSpecificConnection(NotificationDTO notification, string connectionId);
    }
}
