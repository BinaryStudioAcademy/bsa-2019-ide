using IDE.Common.DTO.Image;
using IDE.Common.DTO.User;
using IDE.Common.Enums;
using System;
using System.Collections.Generic;

namespace IDE.Common.DTO.Common
{
    public class ProjectDTO
    {
        public ProjectDTO()
        {
            Builds = new List<BuildDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ProjectLink { get; set; }
        public int CountOfSaveBuilds { get; set; }
        public int CountOfBuildAttempts { get; set; }
        public Language Language { get; set; }
        public ProjectType ProjectType { get; set; }
        public CompilerType CompilerType { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public UserDTO Author { get; set; }
        public GitCredentialDTO GitCredential { get; set; }
        public ImageDTO Logo { get; set; }
        public ICollection<BuildDTO> Builds { get; set; }
    }
}
