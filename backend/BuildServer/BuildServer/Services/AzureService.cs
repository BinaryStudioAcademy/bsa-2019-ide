using BuildServer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Storage.Interfaces;
using System;
using System.Threading.Tasks;

namespace BuildServer.Services
{
    public class AzureService : IAzureService
    {
        private readonly ILogger<AzureService> _logger;
        private readonly string _outputDirectory;
        private readonly string _inputDirectory;
        private readonly IBlobRepository _blobRepository;

        public AzureService(IConfiguration configuration,
                            IBlobRepository blobRepository, ILogger<AzureService> logger)
        {
            _blobRepository = blobRepository;
            _outputDirectory = configuration.GetSection("OutputDirectory").Value;
            _inputDirectory = configuration.GetSection("InputDirectory").Value;
            _logger = logger;
        }

        public async Task<Uri> Upload(string fileName)
        {
            _logger.LogInformation("Upload to azure");
            return await _blobRepository.UploadArtifactFromPathOnServer($"{_outputDirectory}{fileName}.zip");
        }

        public async Task Download(Uri downloadUri, string fileName)
        {
            _logger.LogInformation("Download from  azure");
            await _blobRepository.DownloadFileByUrlAsync(downloadUri, $"{_inputDirectory}{fileName}.zip");
        }
    }
}
