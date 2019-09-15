using IDE.Common.Enums;

namespace IDE.DAL.Entities
{
    public class GitCredential
    {
        public int Id { get; set; }
        public GitProvider Provider { get; set; }
        public string Url { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
