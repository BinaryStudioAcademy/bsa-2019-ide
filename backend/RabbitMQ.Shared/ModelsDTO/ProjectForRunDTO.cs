using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Shared.ModelsDTO
{
    public class ProjectForRunDTO
    {
        public int ProjectId { get; set; }
        public string ConnectionId { get; set; }

        public Uri UriForProjectDownload { get; set; }

        public DateTime TimeStamp { get; set; }
        public string[] Inputs { get; set; }
    }
}
