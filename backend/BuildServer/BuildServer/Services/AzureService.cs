using BuildServer.Interfaces;
using Microsoft.Extensions.Configuration;
using Storage.Interfaces;
using System.IO;
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

        public async Task Upload(string fileName)
        {
            _ = await _blobRepository.UploadFileFromPathOnServer($"{_outputDirectory}{fileName}.zip", "Artifacts");
        }

        public async Task Download(string fileName)
        {
            await _blobRepository.DownloadOnDiskAsync($"{fileName}.zip", $"{_inputDirectory}{fileName}.zip").ConfigureAwait(false);
        }
    }
}
