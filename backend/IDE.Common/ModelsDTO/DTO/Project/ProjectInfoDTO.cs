using IDE.Common.DTO.Common;
using IDE.Common.Enums;
using System;

namespace IDE.Common.DTO.Project
{
    public class ProjectInfoDTO
    {
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
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public GitCredentialDTO GitCredential { get; set; }
    }
}
