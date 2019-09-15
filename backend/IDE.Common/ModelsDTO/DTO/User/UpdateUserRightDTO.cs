using IDE.Common.Enums;

namespace IDE.Common.ModelsDTO.DTO.User
{
    public class UpdateUserRightDTO
    {
        public int ProjectId { get; set; }
        public UserAccess Access { get; set; }
        public int UserId { get; set; }
    }
}
