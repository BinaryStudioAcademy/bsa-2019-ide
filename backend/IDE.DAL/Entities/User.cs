using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LastActive { get; set; }
        public string LogoUrl { get; set; }
        public string GitHubUrl { get; set; }
    }
}
