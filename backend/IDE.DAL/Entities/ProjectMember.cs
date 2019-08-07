using IDE.Common.Enums;

namespace IDE.DAL.Entities
{
    public class ProjectMember
    {
        public UserAccess UserAccess { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
