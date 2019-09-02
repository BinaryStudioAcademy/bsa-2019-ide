using System;

namespace RabbitMQ.Shared.ModelsDTO
{
    public class BuildResultDTO
    {
        public int ProjectId { get; set; }

        public Uri UriForArtifactsDownload { get; set; }

        public bool WasBuildSucceeded { get; set; }
        public string Message { get; set; }
    }
}
