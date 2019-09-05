using BuildServer.Helpers;
using BuildServer.Interfaces;
using BuildServer.OperationsResults;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;

namespace BuildServer.Services.Builders
{
    public class CSharpConsoleBuilder : IBuilder
    {
        private string _buildDirectory;
        ProcessKiller _processKiller;

        public CSharpConsoleBuilder(IConfiguration configuration, ProcessKiller processKiller)
        {
            _buildDirectory = configuration.GetSection("BuildDirectory").Value;
            _processKiller = processKiller;
        }

        public BuildResult Build(string projectName)
        {
            var commandToBuild = $"/c dotnet build {_buildDirectory}\\{projectName}";
            var outputMessage = "";

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"cmd",
                        Arguments = commandToBuild,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    outputMessage += line + "\n";
                }

                process.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var buildResult = new BuildResult()
            {
                IsSuccess = outputMessage.ToLower().Contains("Build succeeded".ToLower()),
                Message = outputMessage
            };

            return buildResult;
        }

        public string Run(string projectName, params string[] inputs)
        {
            var projNames = GetCsProjProjectName(projectName);
            if (projNames.Length == 0 || projNames.Length > 1)
                return "There is no startup files, or there is more than one of them";
            var projName = projNames[0].Substring(projNames[0].LastIndexOf('\\') + 1).Replace(".csproj", ".dll");

            using (Process p = new Process())
            {

                p.StartInfo = new ProcessStartInfo()
                {
                    FileName = "dotnet",
                    Arguments = $"{_buildDirectory}{projectName}\\bin\\Debug\\netcoreapp2.2\\{projName}",
                    //p.StartInfo.RedirectStandardInput = true;
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                _processKiller.KillProcess(p);
                p.Start();

                StreamWriter writer = p.StandardInput;
                int count = 0;
                while(count<inputs.Length)
                {
                    writer.WriteLine(inputs[count]);
                    count++;
                }

                writer.Dispose();

                string output = "";
                string line = "";
                while (!p.StandardOutput.EndOfStream)
                {
                    line = p.StandardOutput.ReadLine();
                    output += line + '\n';
                }
                if (!p.StandardError.EndOfStream)
                {
                    output += p.StandardError.ReadToEnd();
                }
                p.WaitForExit();

                return output;
            }
        } 
        private string[] GetCsProjProjectName(string projectName)
        {
            return Directory.GetFiles($"{_buildDirectory}{projectName}", "*.csproj", SearchOption.TopDirectoryOnly);
        }
    }
}
