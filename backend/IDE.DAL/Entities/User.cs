using System;
using System.Collections.Generic;

namespace IDE.DAL.Entities
{
    public class User
    {
        public User()
        {
            Projects = new List<Project>();
            Builds = new List<Build>();
            ProjectMembers = new List<ProjectMember>();
            FavouriteProjects = new List<FavouriteProjects>();
            Notifications = new List<Notification>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string GitHubUrl { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LastActive { get; set; }
        public bool EmailConfirmed { get; set; }
        public EditorSetting EditorSettings { get;set; }

        public int? AvatarId { get; set; }
        public Image Avatar { get; set; }

        public IList<Project> Projects { get; set; }
        public IList<Build> Builds { get; set; }
        public IList<ProjectMember> ProjectMembers { get; set; }
        public IList<FavouriteProjects> FavouriteProjects { get; set; }
        public IList<Notification> Notifications { get; set; }
    }
}
