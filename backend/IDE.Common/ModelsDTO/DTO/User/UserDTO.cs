using System;

namespace IDE.Common.DTO.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string GitHubUrl { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LastActive { get; set; }
        public string Url { get; set; }
    }
}
