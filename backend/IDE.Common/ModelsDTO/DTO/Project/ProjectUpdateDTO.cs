using IDE.Common.Enums;

namespace IDE.Common.DTO.Project
{
    public class ProjectUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountOfSaveBuilds { get; set; }
        public int CountOfBuildAttempts { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public string Color { get; set; }
    }
}
