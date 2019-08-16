using IDE.Common.Enums;

namespace IDE.Common.DTO.Project
{
    public class ProjectCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }
        public ProjectType ProjectType { get; set; }
        public CompilerType CompilerType { get; set; }
        public int CountOfSaveBuilds { get; set; }
        public int CountOfBuildAttempts { get; set; }
        public string Color { get; set; }
        public AccessModifier Access { get; set; }
    }
}
