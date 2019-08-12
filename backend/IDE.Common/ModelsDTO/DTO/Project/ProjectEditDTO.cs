using IDE.Common.Enums;

namespace IDE.Common.DTO.Project
{
    public class ProjectEditDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AccessModifier AccessModifier { get; set; }
    }
}
