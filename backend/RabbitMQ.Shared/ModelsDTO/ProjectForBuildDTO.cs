using RabbitMQ.Shared.ModelsDTO.Enums;
using System;

namespace RabbitMQ.Shared.ModelsDTO
{
    public class ProjectForBuildDTO
    {
        public int ProjectId { get; set; }

        public ProjectLanguageType Language { get; set; }

        public Uri UriForProjectDownload { get; set; }

        public DateTime TimeStamp { get; set; }
        public int BuildId { get; set; }
    }
}
