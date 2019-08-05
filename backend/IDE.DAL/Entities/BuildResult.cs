using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class BuildResult
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public DateTime BuildStarted { get; set; }
        public DateTime BuildFinished { get; set; }
        public BuildStatuses BuildStatus { get; set; }
        public string BuildMessage { get; set; } 
    }
}
