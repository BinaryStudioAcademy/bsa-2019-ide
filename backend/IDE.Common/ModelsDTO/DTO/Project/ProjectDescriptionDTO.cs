using IDE.Common.Enums;
using IDE.Common.ModelsDTO.DTO.Common;
using System;

namespace IDE.Common.DTO.Project
{
    public class ProjectDescriptionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public int CreatorId { get; set; }
        public DateTime Created { get; set; }
        public bool Favourite { get; set; }
        public BuildStatus? BuildStatus { get; set; }
        public DateTime? LastBuild { get; set; }
        public string Color { get; set; }
    }
}
