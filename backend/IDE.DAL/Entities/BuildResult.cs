using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities
{
    public class BuildResult
    {
        int Id { get; set; }
        int ProjectId { get; set; }
        int UserId { get; set; }
        DateTime BuildStarted { get; set; }
        DateTime BuildFinished { get; set; }
        BuildStatuses BuildStatus { get; set; }
        string BuildMessage { get; set; } 
    }
}
