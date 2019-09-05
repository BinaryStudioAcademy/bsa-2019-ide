using BuildServer.OperationsResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildServer.Interfaces
{
    public interface IBuilder
    {
        BuildResult Build(string projectName);
        string Run(string projectName, params string[] inputs);
    }
}
