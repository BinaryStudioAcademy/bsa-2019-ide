using IDE.Common.ModelsDTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Workspace
{
    public class FileDTO
    {
        public FileDTO()
        {
            NestedFiles = new List<FileDTO> ();
        }
        public string Id { get; set; }
        public TreeNodeType Type { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public ICollection<FileDTO> NestedFiles { get; set; }
    }
}
