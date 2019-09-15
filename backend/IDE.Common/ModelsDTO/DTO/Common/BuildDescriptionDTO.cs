using IDE.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.Common.ModelsDTO.DTO.Common
{
    public class BuildDescriptionDTO
    {
        public string BuildMessage { get; set; }
        public DateTime BuildStarted { get; set; }
        public DateTime? BuildFinished { get; set; }
        public BuildStatus BuildStatus { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
        public string UriForArtifactsDownload { get; set; }
    }
}
