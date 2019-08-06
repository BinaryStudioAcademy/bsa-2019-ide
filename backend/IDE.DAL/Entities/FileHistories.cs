using System;

namespace IDE.DAL.Entities
{
    public class FileHistories
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdaterId { get; set; }
        public User Updater { get; set; }
        public string Content { get; set; }
    }
}
