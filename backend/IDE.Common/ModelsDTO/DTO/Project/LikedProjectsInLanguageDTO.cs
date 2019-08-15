using IDE.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Project
{
    public class LikedProjectInLanguageDTO
    {
        public Language ProjectType { get; set; }
        public LikedProjectDTO[] LikedProjects { get; set; }
    }
}
