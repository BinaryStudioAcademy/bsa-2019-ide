using IDE.Common.Enums;
using System;
using System.Collections.Generic;

namespace IDE.DAL.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Languages Language { get; set; }
        public ProjectTypes ProjectType { get; set; }
        public CompilerTypes CompilerType { get; set; }
        public AccessModifiers AccessModifier { get; set; }
        public string ProjectLink { get; set; }
        public int AuthorId { get; set; }

        public User Author { get; set; }
        public string GitUrl{ get; set; }
        public string GitCredentials { get; set; }
        public int CountOfSaveBuilds { get; set; }
        public int CountOfBuildAttempts { get; set; }

        public IList<Build> Builds { get; set; }
        public IList<ProjectMember> ProjectMembers { get; set; }
    }
}
