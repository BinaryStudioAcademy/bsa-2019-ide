using BuildServer.Helpers;
using BuildServer.Interfaces;
using BuildServer.OperationsResults;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BuildServer.Services.Builders
{
    public class TSConsoleBuilder : IBuilder
    {
        private string _buildDirectory;
        ProcessKiller _processKiller;

        public TSConsoleBuilder(IConfiguration configuration, ProcessKiller processKiller)
        {
            _buildDirectory = configuration.GetSection("BuildDirectory").Value;
            _processKiller = processKiller;
        }

        public BuildResult Build(string projectName)
        {
            var commandToBuild = $"/c (cd {_buildDirectory}\\{projectName} && tsc main.ts)";
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

            BuildResult buildResult = new BuildResult()
            {
                IsSuccess = outputMessage.Length == 0,
                Message = outputMessage
            };

            return buildResult;
        }

        public string Run(string projectName, params string[] inputs)
        {
            //Run ts projects implementation
            throw new NotImplementedException();
            var commandToBuild = $"/c (cd {_buildDirectory}\\{projectName} && node {projectName}.js)";
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
        }
    }
}
