using BuildServer.Helpers;
using BuildServer.Interfaces;
using BuildServer.OperationsResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BuildServer.Services.Builders
{
    public class GoConsoleBuilder : Abstract.Builder<GoConsoleBuilder>, IBuilder
    {
        private readonly string _buildDirectory;
        public GoConsoleBuilder(IConfiguration configuration, ProcessKiller processKiller, ILogger<GoConsoleBuilder> logger)
        : base(processKiller, logger)
        {
            _buildDirectory = configuration.GetSection("BuildDirectory").Value;
        }

        public BuildResult Build(string projectName)
        {
            var commandToBuild = $"/c go build {_buildDirectory}\\{projectName}";
            return BuildInternal(commandToBuild);
        }

        public string Run(string projectName, params string[] inputs)
        {
            var runCommand = $"/c go run {_buildDirectory}\\{projectName}\\main.go";
            return RunInternal(runCommand, inputs);
        }
    }
}
