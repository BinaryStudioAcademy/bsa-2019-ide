using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Workspace
{
    public class ProjectStructureDTO
    {
        public ProjectStructureDTO()
        {
            NestedFiles = new List<FileDTO>();
        }
        public string Id { get; set; }
        public ICollection<FileDTO> NestedFiles { get; set; }
    }
}
