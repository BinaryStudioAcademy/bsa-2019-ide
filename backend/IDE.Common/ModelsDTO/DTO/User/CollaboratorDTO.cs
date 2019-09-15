using IDE.Common.Enums;

namespace IDE.Common.ModelsDTO.DTO.User
{
    public class CollaboratorDTO: UserNicknameDTO
    {
        public UserAccess Access { get; set; }
    }
}
