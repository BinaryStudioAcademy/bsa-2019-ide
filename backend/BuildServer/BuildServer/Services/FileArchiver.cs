using BuildServer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.IO.Compression;

namespace BuildServer.Services
{
    public class FileArchiver : IFileArchiver
    {
        private readonly ILogger<FileArchiver> _logger;
        private readonly string _outputDirectory;
        private readonly string _buildDirectory;
        private readonly string _inputDirectory;

        public FileArchiver(IConfiguration configuration, ILogger<FileArchiver> logger)
        {
            _outputDirectory = configuration.GetSection("OutputDirectory").Value;
            _buildDirectory = configuration.GetSection("BuildDirectory").Value;
            _inputDirectory = configuration.GetSection("InputDirectory").Value;
            _logger = logger;
        }

        public void CreateArchive(string project)
        {
            _logger.LogInformation("Create Archive");
            ZipFile.CreateFromDirectory(_buildDirectory + project, _outputDirectory + project + ".zip");
        }

        public void UnZip(string project)
        {
            _logger.LogInformation("Unzip");
            ZipFile.ExtractToDirectory(_inputDirectory + project + ".zip", _buildDirectory + project);
        }

        public void RemoveTemporaryFiles(string fileName)
        {
            _logger.LogInformation("remove temp files");
            //from Build
            try
            {
                Directory.Delete(_buildDirectory + fileName, true);
                //Console.WriteLine("Directory deleted");
            }
            catch (IOException ioExp)
            {
                _logger.LogError(ioExp, "Start dot net build error");
                //Console.WriteLine(ioExp.Message);
            }
            //from Input
            DeleteFile(_inputDirectory + fileName);
            DeleteFile(_outputDirectory + fileName);
        }

        private void DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(Path.Combine(filePath + ".zip")))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(filePath + ".zip"));
                    //Console.WriteLine("File deleted.");
                }
                else
                {
                    //Console.WriteLine("File not found");
                }
            }
            catch (IOException ioExp)
            {
                _logger.LogError(ioExp, "Start dot net build error");
                Console.WriteLine(ioExp.Message);
            }
        }
    }

}
