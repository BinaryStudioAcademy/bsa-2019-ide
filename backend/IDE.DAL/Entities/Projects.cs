using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Languages Language { get; set; }
        public ProjectTypes ProjectType { get; set; }
        public CompilerTypes CompilerType { get; set; }
        public int MyProperty { get; set; }
        public string ProjectLink { get; set; }
        public int AuthorId { get; set; }
        public string GitUrl{ get; set; }
        public string GitCredentials { get; set; }
        public int CountOfSaveBuilds { get; set; }
        public int CountOfBuildAttempts { get; set; }
    }
}
