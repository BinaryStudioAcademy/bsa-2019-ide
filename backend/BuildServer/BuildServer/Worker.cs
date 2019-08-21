using BuildServer.Helpers;
using BuildServer.Interfaces;
using System;

namespace BuildServer
{
    public class Worker
    {
        private readonly IBuilder _builder;
        private readonly IFileArchiver _fileArchiver;

        public Worker(IBuilder builder, IFileArchiver fileArchiver)
        {
            _builder = builder;
            _fileArchiver = fileArchiver;
        }

        public void Work(string projectName)
        {
            //Delete from build and output file with name projectName. After BlobStorage integration,
            //these files will be deteled at the end of the Work(after uploading to the blobstorge)
            _fileArchiver.DeleteFile(projectName);
            _fileArchiver.DeleteDirectory(projectName);

            _fileArchiver.UnZip(projectName);

            string buildResult = _builder.Build(projectName);
            string executeResult = _builder.Execute(projectName);

            //I left it here because we won`t use it later
            //RabbitMq can send this data
            FileHelper.WriteToFile($"..\\..\\..\\..\\Build\\{projectName}\\BuildResult.txt", buildResult);
            FileHelper.WriteToFile($"..\\..\\..\\..\\Build\\{projectName}\\Output.txt", executeResult);

            _fileArchiver.CreateArchive(projectName);

            Console.WriteLine(buildResult);
            Console.WriteLine("program output:");
            Console.WriteLine(executeResult);
        }
    }

}
