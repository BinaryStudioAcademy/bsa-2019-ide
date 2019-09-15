using BuildServer.Helpers;
using BuildServer.Interfaces;
using BuildServer.OperationsResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace BuildServer.Services.Builders
{
    public class TSConsoleBuilder : Abstract.Builder<TSConsoleBuilder>, IBuilder
    {
        private readonly string _buildDirectory;
        public TSConsoleBuilder(IConfiguration configuration, ProcessKiller processKiller, ILogger<TSConsoleBuilder> logger)
        : base(processKiller, logger)
        {
            _buildDirectory = configuration.GetSection("BuildDirectory").Value;
        }

        public BuildResult Build(string projectName)
        {
            var commandToBuild = $"/c tsc {_buildDirectory}\\{projectName}\\main.ts";
            return BuildInternal(commandToBuild);
        }

        public string Run(string projectName, params string[] inputs)
        {
            //Run ts projects implementation
            throw new NotImplementedException();
        }
    }
}
