using BuildServer.Interfaces;
using BuildServer.OperationsResults;
using RabbitMQ.Shared.ModelsDTO.Enums;
using System;

namespace BuildServer
{
    public class Worker
    {
        private readonly IProjectBuilder _builder;
        private readonly IFileArchiver _fileArchiver;
        private readonly IAzureService _azureService;

        public Worker(
            IProjectBuilder builder,
            IFileArchiver fileArchiver,
            IAzureService azureService)
        {
            _builder = builder;
            _fileArchiver = fileArchiver;
            _azureService = azureService;
        }

        public BuildResult Build(Uri uriForDownload, string projectName, ProjectLanguageType type, out Uri artifactArchiveUri)
        {
            Console.WriteLine("Downloading...");
            _azureService.Download(uriForDownload, projectName).GetAwaiter().GetResult();

            Console.WriteLine("UnZiping...");
            _fileArchiver.UnZip(projectName);

            Console.WriteLine("Building...");
            var buildResult = _builder.Build(projectName, type);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Build result:");
            Console.WriteLine(buildResult.Message);
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Creating archive...");
            _fileArchiver.CreateArchive(projectName);

            Console.WriteLine("Uploading artifacts to blob...");
            artifactArchiveUri = _azureService.Upload(projectName).GetAwaiter().GetResult();

            Console.WriteLine("Removing temporary files...");
            _fileArchiver.RemoveTemporaryFiles(projectName);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Message was handled! Is build succeeded: {buildResult.IsSuccess}");
            Console.ForegroundColor = ConsoleColor.White;

            return buildResult;
        }

        public string Run(Uri uriForDownload, string projectName)
        {
            Console.WriteLine("Downloading...");
            _azureService.Download(uriForDownload, projectName).GetAwaiter().GetResult();
            Console.WriteLine("UnZiping...");
            _fileArchiver.UnZip(projectName);

            Console.WriteLine("Build project");
            var buildResult = _builder.Build(projectName, ProjectLanguageType.CSharpConsoleApp);

            if (!buildResult.IsSuccess)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Build Failed");
                Console.WriteLine("Removing temporrary files...");
                Console.ForegroundColor = ConsoleColor.White;
                _fileArchiver.RemoveTemporaryFiles(projectName);
                return "Fail while building \n" + buildResult;
            }

            Console.WriteLine("Build result:");
            Console.WriteLine(buildResult);

            Console.WriteLine("Running project");
            string executeResult = _builder.Run(projectName, ProjectLanguageType.CSharpConsoleApp);

            Console.WriteLine("Removing temporrary files...");
            _fileArchiver.RemoveTemporaryFiles(projectName);
            
            Console.WriteLine("program output:");
            Console.WriteLine(executeResult);

            return executeResult;
        }
    }
}
