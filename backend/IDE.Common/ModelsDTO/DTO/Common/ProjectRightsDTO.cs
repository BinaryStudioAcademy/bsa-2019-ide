using IDE.Common.Enums;

namespace IDE.Common.ModelsDTO.DTO.Common
{
    public class ProjectRightsDTO
    {
        public bool IsAuthor { get; set; }
        public UserAccess? Access { get; set; }
    }
}
