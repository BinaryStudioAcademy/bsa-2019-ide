using IDE.Common.Enums;

namespace IDE.Common.DTO.User
{
    public class SocialAuthUserDetailsDTO
    {
        public string AccountId { get; set; }
        public SocialProvider Provider { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string GitHubUrl { get; set; }
        public string Picture { get; set; }
    }
}
