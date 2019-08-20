using IDE.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Common
{
    public class ProjectRightsDTO
    {
        public bool IsAuthor { get; set; }
        public UserAccess? Access { get; set; }
    }
}
