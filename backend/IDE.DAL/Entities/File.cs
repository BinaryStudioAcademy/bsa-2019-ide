using System;

namespace IDE.DAL.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Folder { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }

        public int FileHistoryId { get; set; }
        public FileHistory FileHistory { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
