using BuildServer.Interfaces;
using Microsoft.Extensions.Configuration;
using Storage.Interfaces;
using System;
using System.Threading.Tasks;

namespace BuildServer.Services
{
    public class AzureService : IAzureService
    {
        private readonly string _outputDirectory;
        private readonly string _inputDirectory;
        private readonly IBlobRepository _blobRepository;

        public AzureService(IConfiguration configuration,
                            IBlobRepository blobRepository)
        {
            _blobRepository = blobRepository;
            _outputDirectory = configuration.GetSection("OutputDirectory").Value;
            _inputDirectory = configuration.GetSection("InputDirectory").Value;
        }

        public async Task<Uri> Upload(string fileName)
        {
            return await _blobRepository.UploadArtifactFromPathOnServer($"{_outputDirectory}{fileName}.zip");
        }

        public async Task Download(Uri downloadUri, string fileName)
        {
            await _blobRepository.DownloadFileByUrlAsync(downloadUri, $"{_inputDirectory}{fileName}.zip");
        }
    }
}
