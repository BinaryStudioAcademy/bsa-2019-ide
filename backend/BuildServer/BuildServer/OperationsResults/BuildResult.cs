using System;
using System.Collections.Generic;
using System.Text;

namespace BuildServer.OperationsResults
{
    public class BuildResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
