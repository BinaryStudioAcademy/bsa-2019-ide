using IDE.Common.Enums;
using System;

namespace IDE.DAL.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public NotificationStatus Status { get; set; }
        public NotificationType Type { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public int? ProjectId { get; set; }
        public string Metadata { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
