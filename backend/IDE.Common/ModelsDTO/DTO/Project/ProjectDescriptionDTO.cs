using System;

namespace IDE.Common.DTO.Project
{
    public class ProjectDescriptionDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
        public string PhotoLink { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastBuild { get; set; }
    }
}
