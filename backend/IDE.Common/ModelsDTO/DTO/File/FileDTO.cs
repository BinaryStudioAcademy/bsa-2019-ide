using IDE.Common.DTO.User;
using System;

namespace IDE.Common.DTO.File
{
    public class FileDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Content { get; set; }
        public string Folder { get; set; }
        public int ProjectId { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatorId { get; set; }
        public UserDTO Creator { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UpdaterId { get; set; }
        public UserDTO Updater { get; set; }
    }
}
