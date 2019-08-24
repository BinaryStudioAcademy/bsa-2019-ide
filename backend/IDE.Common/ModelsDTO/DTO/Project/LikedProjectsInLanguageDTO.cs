using IDE.Common.Enums;

namespace IDE.Common.ModelsDTO.DTO.Project
{
    public class LikedProjectInLanguageDTO
    {
        public Language ProjectType { get; set; }
        public LikedProjectDTO[] LikedProjects { get; set; }
    }
}
