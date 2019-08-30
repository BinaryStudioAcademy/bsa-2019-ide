using System;

namespace RabbitMQ.Shared.ModelsDTO
{
    public class ProjectForBuildDTO
    {
        public int ProjectId { get; set; }

        public Uri UriForProjectDownload { get; set; }
    }
}
