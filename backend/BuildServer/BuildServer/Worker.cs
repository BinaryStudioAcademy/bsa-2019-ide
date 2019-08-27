using BuildServer.Helpers;
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

        public bool Work(string projectName)
        {
            Console.WriteLine("Downloading...");
            _azureService.Download(projectName);

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

            //I left it here because we won`t use it later
            //RabbitMq can send this data
            FileHelper.WriteToFile($"..\\..\\..\\..\\Build\\{projectName}\\BuildResult.txt", buildResult);
            FileHelper.WriteToFile($"..\\..\\..\\..\\Build\\{projectName}\\Output.txt", executeResult);

            _fileArchiver.CreateArchive(projectName);

            Console.WriteLine("Uploading artifacts to blob...");
            _azureService.Upload(projectName);

            Console.WriteLine("Removing temporrary files...");
            _fileArchiver.RemoveTemporaryFiles(projectName);

            Console.WriteLine("Build result:");
            Console.WriteLine(buildResult);
            //Console.WriteLine("program output:");
            //Console.WriteLine(executeResult);

            return isBuildSucceeded;
        }
    }

}
