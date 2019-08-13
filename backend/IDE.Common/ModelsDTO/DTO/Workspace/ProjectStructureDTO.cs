using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Workspace
{
    public class ProjectStructureDTO
    {
        public ProjectStructureDTO()
        {
            NestedFiles = new List<FileStructureDTO>();
        }

        public string Id { get; set; }
        public ICollection<FileStructureDTO> NestedFiles { get; set; }
    }
}
