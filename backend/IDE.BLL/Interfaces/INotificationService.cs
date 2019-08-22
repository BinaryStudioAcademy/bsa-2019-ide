using IDE.Common.ModelsDTO.DTO.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDTO>> GetNotificationsByUserId(int userId);
        Task<NotificationDTO> SendNotification(int projectId, NotificationDTO notificationDTO);
    }
}
