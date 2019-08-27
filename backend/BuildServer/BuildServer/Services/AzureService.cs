using BuildServer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;

namespace BuildServer.Services
{
    public class AzureService : IAzureService
    {
        private const int URL_PARTS_COUNT = 3; // In Azure it's 4, local it's 5
        private readonly string _storageConnectionString;
        private readonly string _container;
        private readonly string _outputDirectory;
        private readonly string _inputDirectory;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _blobContainer;

        public AzureService(IConfiguration configuration)
        {
            _storageConnectionString = configuration.GetSection("StorageConnectionString").Value;

            _container = configuration.GetSection("Container").Value;
            _outputDirectory = configuration.GetSection("OutputDirectory").Value;
            _inputDirectory = configuration.GetSection("InputDirectory").Value;
        }

        public void Upload(string fileName)
        {
            var container = GetBlobContainer(_container);
            var dir = container.GetDirectoryReference($"buildArtifacts");

            //container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Blob).GetAwaiter().GetResult();

            var blockBlob = dir.GetBlockBlobReference($"{fileName}.zip");
            using (var fileStream = File.OpenRead($"{_outputDirectory}{fileName}.zip"))
            {
                blockBlob.UploadFromStreamAsync(fileStream).GetAwaiter().GetResult();
            }
        }

        public void Download(string fileName)
        {
            var blobContainer = GetBlobContainer(_container);
            var dir = blobContainer.GetDirectoryReference($"projectsToBuild");
            var blockBlob = dir.GetBlockBlobReference($"{fileName}.zip");
            using (var fileStream = File.OpenWrite($"{_inputDirectory}{fileName}.zip"))
            {
                blockBlob.DownloadToStreamAsync(fileStream).GetAwaiter().GetResult();
            }
        }

        public CloudBlobContainer GetBlobContainer(string containerNameKey)
        {
            if (_blobContainer != null)
            {
                return _blobContainer;
            }

            var blobClient = GetBlobClient();

            _blobContainer = blobClient.GetContainerReference(containerNameKey);

            if (_blobContainer.CreateIfNotExistsAsync().GetAwaiter().GetResult())
            {
                _blobContainer.SetPermissionsAsync(new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    }
                );
            }

            return _blobContainer;
        }

        private CloudBlobClient GetBlobClient()
        {
            if (_blobClient != null)
            {
                return _blobClient;
            }

            if (!CloudStorageAccount.TryParse(_storageConnectionString, out var storageAccount))
            {
                throw new Exception("Could not create storage account with StorageConnectionString configuration");
            }

            _blobClient = storageAccount.CreateCloudBlobClient();
            return _blobClient;
        }
    }
}
