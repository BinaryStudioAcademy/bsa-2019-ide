using IDE.Common.Enums;
using System;
using System.Collections.Generic;

namespace IDE.DAL.Entities
{
    public class Build
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public DateTime BuildStarted { get; set; }
        public DateTime BuildFinished { get; set; }
        public BuildStatuses BuildStatus { get; set; }
        public string BuildMessage { get; set; }

        public User User { get; set; }
        public Project Project { get; set; }
        public IList<LastSuccessfulBuild> LastSuccessfulBuilds { get; set; }

    }
}
