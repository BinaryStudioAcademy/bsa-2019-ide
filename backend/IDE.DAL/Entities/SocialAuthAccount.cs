using IDE.Common.Enums;

namespace IDE.DAL.Entities
{
    public class SocialAuthAccount
    {
        public int Id { get; set; }
        public SocialProvider Provider { get; set; }
        public string AccountId { get; set; }

        public int UserId{ get; set; }  
        public User User { get; set; }
    }
}
