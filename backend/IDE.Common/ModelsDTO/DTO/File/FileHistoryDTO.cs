using IDE.Common.DTO.User;
using System;

namespace IDE.Common.DTO.File
{
    public class FileHistoryDTO
    {
        public string Id { get; set; }
        public string FileId { get; set; }

        public string Name { get; set; }
        public string Content { get; set; }
        public string Folder { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatorId { get; set; }
    }
}
