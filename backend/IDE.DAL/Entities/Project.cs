using IDE.Common.Enums;
using System;
using System.Collections.Generic;

namespace IDE.DAL.Entities
{
    public class Project
    {
        public Project()
        {
            Builds = new List<Build>();
            ProjectMembers = new List<ProjectMember>();
            FavouriteProjects = new List<FavouriteProjects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPrivate { get; set; }
        public string ProjectLink { get; set; }
        public int CountOfSaveBuilds { get; set; }
        public int CountOfBuildAttempts { get; set; }
        public Language Language { get; set; }
        public ProjectType ProjectType { get; set; }
        public CompilerType CompilerType { get; set; }
        public AccessModifier AccessModifier { get; set; }

        public string Color { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }

        public int? GitCredentialId { get; set; }
        public GitCredential GitCredential { get; set; }

        public ICollection<Build> Builds { get; set; }
        public ICollection<ProjectMember> ProjectMembers { get; set; }
        public ICollection<FavouriteProjects> FavouriteProjects { get; set; }
    }
}
