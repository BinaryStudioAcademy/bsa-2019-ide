using BuildServer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace BuildServer.Services
{
    public class AzureService : IAzureService
    {
        private readonly string _storageAccountName;
        private readonly string _storageAccountKey;
        private readonly string _container;
        private readonly string _outputDirectory;
        private readonly string _inputDirectory;

        public AzureService(IConfiguration configuration)
        {
            _storageAccountName = configuration.GetSection("StorageAccountName").Value;
            _storageAccountKey = configuration.GetSection("StorageAccountKey").Value;
            _container = configuration.GetSection("Container").Value;
            _outputDirectory = configuration.GetSection("OutputDirectory").Value;
            _inputDirectory = configuration.GetSection("InputDirectory").Value;
        }

        public void Upload(string fileName)
        {
            var storageAccount = new CloudStorageAccount(
                            new StorageCredentials(_storageAccountName, _storageAccountKey), true);

            var myClient = storageAccount.CreateCloudBlobClient();
            var container = myClient.GetContainerReference(_container);
            //container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Blob).GetAwaiter().GetResult();

            var blockBlob = container.GetBlockBlobReference($"{fileName}.zip");
            using (var fileStream = System.IO.File.OpenRead($"{_outputDirectory}{fileName}.zip"))
            {
                blockBlob.UploadFromStreamAsync(fileStream).GetAwaiter().GetResult();
            }
        }

        public void Download(string fileName)
        {
            var storageAccount = new CloudStorageAccount(
                            new StorageCredentials(_storageAccountName, _storageAccountKey), true);

            var myClient = storageAccount.CreateCloudBlobClient();
            var container = myClient.GetContainerReference(_container);
            //container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);

            var blockBlob = container.GetBlockBlobReference($"{fileName}.zip");
            using (var fileStream = System.IO.File.OpenWrite($"{_inputDirectory}{fileName}.zip"))
            {
                blockBlob.DownloadToStreamAsync(fileStream).GetAwaiter().GetResult();
            }
        }
        
    }
}
