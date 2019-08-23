using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
