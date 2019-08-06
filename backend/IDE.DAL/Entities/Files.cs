using System;

namespace IDE.DAL.Entities
{
    public class Files
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Folder { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime CreateAt { get; set; }
        public int FIleHistoryId { get; set; }
        public FileHistories FileHistory { get; set; }
    }
}
