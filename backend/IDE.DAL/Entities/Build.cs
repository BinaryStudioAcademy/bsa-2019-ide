﻿using IDE.Common.Enums;
using System;

namespace IDE.DAL.Entities
{
    public class Build
    {
        public int Id { get; set; }
        public string BuildMessage { get; set; }
        public DateTime BuildStarted { get; set; }
        public DateTime? BuildFinished { get; set; }
        public BuildStatus BuildStatus { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        public string UriForArtifactsDownload { get; set; }
    }
}
