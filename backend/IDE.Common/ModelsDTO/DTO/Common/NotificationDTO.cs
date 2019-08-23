using IDE.Common.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Common
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
