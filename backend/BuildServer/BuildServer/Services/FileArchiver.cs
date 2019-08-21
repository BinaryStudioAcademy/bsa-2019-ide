using BuildServer.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.IO.Compression;

namespace BuildServer.Services
{
    public class FileArchiver : IFileArchiver
    {
        private string _outputDirectory;
        private string _buildDirectory;
        private string _inputDirectory;

        public FileArchiver(IConfiguration configuration)
        {
            _outputDirectory = configuration.GetSection("OutputDirectory").Value;
            _buildDirectory = configuration.GetSection("BuildDirectory").Value;
            _inputDirectory = configuration.GetSection("InputDirectory").Value;
        }

        public void CreateArchive(string project)
        {
            ZipFile.CreateFromDirectory(_buildDirectory + project, _outputDirectory + project + ".zip");
        }

        public void UnZip(string project)
        {
            ZipFile.ExtractToDirectory(_inputDirectory + project + ".zip", _buildDirectory + project);
        }


        public void DeleteDirectory(string directoryName)
        {
            try
            {
                Directory.Delete(_buildDirectory + directoryName, true);
                Console.WriteLine("Directory deleted");
            }
            catch (IOException ioExp)
            {
                //Console.WriteLine(ioExp.Message);
            }
        }

        public void DeleteFile(string fileName)
        {
            try
            {
                if (File.Exists(Path.Combine(_outputDirectory, fileName + ".zip")))
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(_outputDirectory, fileName + ".zip"));
                    Console.WriteLine("File deleted.");
                }
                else
                {
                    //Console.WriteLine("File not found");
                }
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
        }
    }

}
