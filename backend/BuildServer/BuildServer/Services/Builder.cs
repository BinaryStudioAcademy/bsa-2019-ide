using BuildServer.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace BuildServer.Services
{
    public class Builder : IBuilder
    {
        private string _buildDirectory;

        public Builder(IConfiguration configuration)
        {
            _buildDirectory = configuration.GetSection("BuildDirectory").Value;
        }

        public string Build(string projectName)
        {
            var commandToBuild = $"/c dotnet build {_buildDirectory}{projectName}\\{projectName}\\{projectName}";
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

            return outputMessage;
        }

        public string Execute(string projectName)
        {
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
                    var line = process.StandardOutput.ReadLine();
                    outputMessage += line + "\n";
                }

                process.WaitForExit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return outputMessage;
        }
    }
}
