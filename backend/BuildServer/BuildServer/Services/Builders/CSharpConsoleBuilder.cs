using BuildServer.Helpers;
using BuildServer.Interfaces;
using BuildServer.OperationsResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace BuildServer.Services.Builders
{
    public class CSharpConsoleBuilder : Abstract.Builder<CSharpConsoleBuilder>, IBuilder
    {
        private readonly string _buildDirectory;
        public CSharpConsoleBuilder(IConfiguration configuration, ProcessKiller processKiller, ILogger<CSharpConsoleBuilder> logger)
        : base(configuration, processKiller, logger)
        {
            _buildDirectory = configuration.GetSection("BuildDirectory").Value;
        }

        public BuildResult Build(string projectName)
        {
            var commandToBuild = $"/c dotnet build {_buildDirectory}\\{projectName} -c Release";
            return BuildInternal(commandToBuild);
        }

        public string Run(string projectName, params string[] inputs)
        {
            var projNames = GetCsProjProjectName(projectName);

            if (projNames.Length == 0 || projNames.Length > 1)
            {
                return "There is no startup files, or there is more than one of them";
            }

            var projName = projNames[0].Substring(projNames[0].LastIndexOf('\\') + 1).Replace(".csproj", ".dll");

            var runCommand = $"/c dotnet {_buildDirectory}{projectName}\\bin\\Release\\netcoreapp2.2\\{projName}";
            return RunInternal(runCommand, inputs);
        }

        private string[] GetCsProjProjectName(string projectName)
        {
            return Directory.GetFiles($"{_buildDirectory}{projectName}", "*.csproj", SearchOption.TopDirectoryOnly);
        }
    }
}
