using IDE.Common.DTO.Common;
using System;

namespace IDE.Common.DTO.File
{
    public class FileDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Folder { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public string FileHistoryId { get; set; }
        public FileHistoryDTO FileHistory { get; set; }

        public int ProjectId { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
