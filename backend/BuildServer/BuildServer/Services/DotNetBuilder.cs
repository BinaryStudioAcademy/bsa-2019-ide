using BuildServer.Helpers;
using BuildServer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace BuildServer.Services
{
    public class DotNetBuilder : IBuilder
    {
        private readonly ILogger<DotNetBuilder> _logger;
        private string _buildDirectory;
        ProcessKiller _processKiller;

        public DotNetBuilder(IConfiguration configuration, ProcessKiller processKiller, ILogger<DotNetBuilder> logger)
        {
            _buildDirectory = configuration.GetSection("BuildDirectory").Value;
            _processKiller = processKiller;
            _logger = logger;
        }

        public string Build(string projectName)
        {
            _logger.LogInformation("Start dot net build");
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
                _logger.LogError(e,"Start dot net build error");
                Console.WriteLine(e.Message);
            }

            return outputMessage;
        }

        public string Execute(string projectName)
        {
            _logger.LogInformation("Start dot net execute");
            //count of nested "projectName" will be depend on the template
            var commandToExecute = $"/c dotnet {_buildDirectory}{projectName}\\{projectName}\\{projectName}\\bin\\Debug\\netcoreapp2.2\\{projectName}.dll run";
            var outputMessage = "";

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"cmd",
                        Arguments = commandToExecute,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLineAsync();
                    outputMessage += line + "\n";
                }

                process.WaitForExit();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Start dot net execute error");
                Console.WriteLine(e.Message);
            }

            return outputMessage;
        }

        public string Run(string projectName)
        {
            _logger.LogInformation("Start dot net run");
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

                //StreamWriter writer = p.StandardInput;

                //string inputText;
                //writer.WriteLine("\n");
                //int numLines = 0;
                //do
                //{
                //    inputText = Console.ReadLine();
                //    if (inputText.Length > 0)
                //    {
                //        numLines++;
                //        writer.WriteLine("\n");
                //    }
                //} while (inputText.Length > 0);
                //writer.Dispose();
                
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
