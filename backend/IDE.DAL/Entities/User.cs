using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class User
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
        string PasswordSalt { get; set; }
        DateTime Birthday { get; set; }
        DateTime RegisteredAt { get; set; }
        DateTime LastActive { get; set; }
        string LogoUrl { get; set; }
        string GitHubUrl { get; set; }
    }
}
