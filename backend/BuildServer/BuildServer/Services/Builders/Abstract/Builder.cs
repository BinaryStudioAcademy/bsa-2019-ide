using BuildServer.Helpers;
using BuildServer.OperationsResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace BuildServer.Services.Builders.Abstract
{
    public abstract class Builder<T>
    {
        private readonly ILogger<T> _logger;
        private ProcessKiller _processKiller;

        public Builder(IConfiguration configuration, ProcessKiller processKiller, ILogger<T> logger)
        {
            _processKiller = processKiller;
            _logger = logger;
        }

        public BuildResult BuildInternal(string buildCommand)
        {
            _logger.LogInformation("Start build command");
            var outputMessage = "";

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = buildCommand,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            try
            {
                _processKiller.KillProcess(process);
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
                _logger.LogError(e, "Start build command error");
                Console.WriteLine(e.Message);
            }
            finally
            {
                process.Dispose();
            }

            var buildResult = new BuildResult()
            {
                IsSuccess = outputMessage.ToLower().Contains("Build succeeded".ToLower()),
                Message = outputMessage
            };

            return buildResult;
        }

        public string RunInternal(string runCommand, params string[] inputs)
        {
            _logger.LogInformation("Start run command");

            using (Process p = new Process())
            {
                p.StartInfo = new ProcessStartInfo()
                {
                    FileName = "cmd",
                    Arguments = runCommand,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                };

                _processKiller.KillProcess(p);
                p.Start();

                var writer = p.StandardInput;
                var count = 0;

                while (count < inputs.Length)
                {
                    writer.WriteLine(inputs[count]);
                    count++;
                }

                writer.Dispose();

                var output = "";
                var line = "";

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
    }
}
