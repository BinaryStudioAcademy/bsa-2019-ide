using IDE.Common.Enums;
using System;

namespace IDE.Common.DTO.Common
{
    public class BuildDTO
    {
        public int Id { get; set; }
        public string BuildMessage { get; set; }
        public DateTime BuildStarted { get; set; }
        public DateTime? BuildFinished { get; set; }
        public BuildStatus BuildStatus { get; set; }
        public int ProjectId { get; set; }
        public int? UserId { get; set; }
    }
}
