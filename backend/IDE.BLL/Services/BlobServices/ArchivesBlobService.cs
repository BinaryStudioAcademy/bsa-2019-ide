﻿using IDE.BLL.Factories.Abstractions;
using IDE.BLL.Services.Abstract;
using IDE.Common.Enums;
using IDE.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Services.BlobServices
{
    public class ArchivesBlobService : IBlobService
    {
        private const int URL_PARTS_COUNT = 3; //In Azure it's 4, local it's 5
        private readonly IAzureBlobConnectionFactory _connectionFactory;

        public ArchivesBlobService(IAzureBlobConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task DeleteAsync(string fileUri)
        {
            var blobContainer = await _connectionFactory.GetArchiveArtifactsBlobContainer();

            var blob = blobContainer.GetBlockBlobReference(GetSubstring(fileUri, '/', URL_PARTS_COUNT));
            await blob.DeleteIfExistsAsync();
        }

        //Download file from full Uri
        public async Task<MemoryStream> DownloadFileAsync(string fileUri)
        {
            var blobContainer = await _connectionFactory.GetArchiveArtifactsBlobContainer();

            var blob = blobContainer.GetBlobReference(GetSubstring(fileUri, '/', URL_PARTS_COUNT));
            using (MemoryStream memStream = new MemoryStream())
            {
                await blob.DownloadToStreamAsync(memStream);
                return memStream;
            }
        }
        
        //Use it to upload files to get list of files urls from folder with name 'pr_{projectId}'
        public async Task<IEnumerable<Uri>> ListAsync(int projectId)
        {
            var blobContainer = await _connectionFactory.GetArchiveArtifactsBlobContainer();
            var directory = blobContainer.GetDirectoryReference(string.Format("pr_{0}", projectId));
            var allBlobs = new List<Uri>();
            BlobContinuationToken blobContinuationToken = null;
            do
            {
                var response = await directory.ListBlobsSegmentedAsync(blobContinuationToken);

                await AddFilesUrlsToList(allBlobs, response);

                blobContinuationToken = response.ContinuationToken;
            } while (blobContinuationToken != null);
            return allBlobs;
        }
        
        //Use it to upload files to folder with name 'pr_{projectId}'
        public async Task<Uri> UploadAsync(IFormFile file, int projectId, int buildId)
        {
            var blobContainer = await _connectionFactory.GetArchiveArtifactsBlobContainer();
            var dir = blobContainer.GetDirectoryReference(string.Format("pr_{0}", projectId));

            var blob = dir.GetBlockBlobReference(GetRandomBlobName(file.FileName, buildId));

            using (var stream = file.OpenReadStream())
            {
                await blob.UploadFromStreamAsync(stream);
            }
            blob.Properties.ContentType = file.ContentType;

            return blob.Uri;
        }


        private string GetSubstring(string stringForSubstring, char desiredChar, int charsCount)
        {
            int startingPos = 0;
            for (int i = 0; i < charsCount; i++)
                startingPos = stringForSubstring.IndexOf(desiredChar, startingPos) + 1;
            return stringForSubstring.Substring(startingPos);
        }
        
        private string GetRandomBlobName(string filename, int buildId)
        {
            string ext = Path.GetExtension(filename);

            return string.Format("{0:10}_{1}{2}", DateTime.Now.Ticks, buildId, ext);
        }

        private async Task<IEnumerable<Uri>> AddFilesUrlsToList(List<Uri> uris, BlobResultSegment response)
        {
            BlobContinuationToken blobContinuationToken = null;
            do
            {
                foreach (IListBlobItem blob in response.Results)
                {
                    if (blob.GetType() == typeof(CloudBlockBlob))
                        uris.Add(blob.Uri);
                    else if (blob is CloudBlobDirectory dir)
                        await AddFilesUrlsToList(uris, await dir.ListBlobsSegmentedAsync(blobContinuationToken));
                }
                blobContinuationToken = response.ContinuationToken;
            } while (blobContinuationToken != null);
            return uris;
        }
    }
}