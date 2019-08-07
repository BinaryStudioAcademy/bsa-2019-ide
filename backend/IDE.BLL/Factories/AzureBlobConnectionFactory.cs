﻿using IDE.BLL.Factories.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Factories
{
    public class AzureBlobConnectionFactory : IAzureBlobConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _blobContainer;

        public AzureBlobConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CloudBlobContainer> GetArchiveArtifactsBlobContainer()
        {
            return await GetBlobContainer("ArchiveArtifactsContainerName");
        }

        public async Task<CloudBlobContainer> GetBlobContainer(string containerNameKey)
        {
            if (_blobContainer != null)
                return _blobContainer;

            var containerName = _configuration.GetValue<string>(containerNameKey);

            var blobClient = GetBlobClient();

            _blobContainer = blobClient.GetContainerReference(containerName);
            if (await _blobContainer.CreateIfNotExistsAsync())
            {
                await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            }
            return _blobContainer;
        }

        private CloudBlobClient GetBlobClient()
        {
            if (_blobClient != null)
                return _blobClient;

            var storageConnectionString = _configuration.GetValue<string>("StorageConnectionString");

            if (!CloudStorageAccount.TryParse(storageConnectionString, out CloudStorageAccount storageAccount))
            {
                throw new Exception("Could not create storage account with StorageConnectionString configuration");
            }

            _blobClient = storageAccount.CreateCloudBlobClient();
            return _blobClient;
        }
    }
}