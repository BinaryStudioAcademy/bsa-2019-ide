using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Shared.ModelsDTO
{
    public class RunResultDTO
    {
        public int ProjectId { get; set; }
        public string ConnectionId { get; set; }

        public string Result { get; set; }
    }
}
