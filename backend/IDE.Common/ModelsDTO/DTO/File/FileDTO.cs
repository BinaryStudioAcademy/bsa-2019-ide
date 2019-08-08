using IDE.Common.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.DTO.File
{
    public class FileDTO
    {
        public string Name { get; set; }
        public string Folder { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }

        public int FileHistoryId { get; set; }
        public FileHistoryDTO FileHistory { get; set; }

        public int ProjectId { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
