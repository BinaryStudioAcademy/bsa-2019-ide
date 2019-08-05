using IDE.Common.Enums;

namespace IDE.DAL.Entities
{
    public class ProjectMembers
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public UserAccesses UserAccess { get; set; }
    }
}
