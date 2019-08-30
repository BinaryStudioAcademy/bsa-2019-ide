using BuildServer.Interfaces;
using System;

namespace BuildServer
{
    public class Worker
    {
        private readonly IBuilder _builder;
        private readonly IFileArchiver _fileArchiver;
        private readonly IAzureService _azureService;

        public Worker(
            IBuilder builder,
            IFileArchiver fileArchiver,
            IAzureService azureService)
        {
            _builder = builder;
            _fileArchiver = fileArchiver;
            _azureService = azureService;
        }

        public bool Work(Uri uriForDownload, string projectName, out Uri artifactArchiveUri)
        {
            Console.WriteLine("Downloading...");
            _azureService.Download(uriForDownload, projectName).GetAwaiter().GetResult();

            Console.WriteLine("UnZiping...");
            _fileArchiver.UnZip(projectName);


            string buildResult = _builder.Build(projectName);

            bool isBuildSucceeded = false;
            string executeResult = "Execution was not performed!!!";
            
            if (buildResult.ToLower().Contains("Build succeeded".ToLower()))
            {
                isBuildSucceeded = true;
                //executeResult = _builder.Execute(projectName);
            }

            _fileArchiver.CreateArchive(projectName);

            Console.WriteLine("Uploading artifacts to blob...");
            artifactArchiveUri = _azureService.Upload(projectName).GetAwaiter().GetResult();

            Console.WriteLine("Removing temporrary files...");
            _fileArchiver.RemoveTemporaryFiles(projectName);

            Console.WriteLine("Build result:");
            Console.WriteLine(buildResult);
            //Console.WriteLine("program output:");
            //Console.WriteLine(executeResult);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Message was handled! Is build succeeded: {isBuildSucceeded}");
            Console.ForegroundColor = ConsoleColor.White;

            return isBuildSucceeded;
        }
    }
}
