using IDE.Common.DTO.User;
using IDE.Common.Enums;
using System;

namespace IDE.Common.DTO.Common
{
    public class BuildDTO
    {
        public string BuildMessage { get; set; }
        public DateTime BuildStarted { get; set; }
        public DateTime? BuildFinished { get; set; }
        public BuildStatus BuildStatus { get; set; }
        public ProjectDTO Project { get; set; }
        public UserDTO User { get; set; }
    }
}
