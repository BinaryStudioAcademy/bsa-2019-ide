using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.User
{
    public class SocialAuthUserCreateDTO
    {
        public string AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string GitHubUrl { get; set; }
        public string Picture { get; set; }
    }
}
