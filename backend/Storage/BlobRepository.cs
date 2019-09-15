using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Blob;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Storage
{
    public class ArchivesBlobRepository : IBlobRepository
    {
        private const int URL_PARTS_COUNT = 3; // In Azure it's 4, local it's 5
        private readonly IAzureBlobConnectionFactory _connectionFactory;

        public ArchivesBlobRepository(IAzureBlobConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task DeleteAsync(string fileUri)
        {
            var blobContainer = await _connectionFactory.GetArtifactsBlobContainer();
            var blob = blobContainer.GetBlockBlobReference(GetSubstring(fileUri, '/', URL_PARTS_COUNT));

            await blob.DeleteIfExistsAsync();
        }

        // Download file from full Uri
        public async Task<MemoryStream> DownloadFileAsync(string fileUri)
        {
            var blobContainer = await _connectionFactory.GetArtifactsBlobContainer();
            var blob = blobContainer.GetBlobReference(GetSubstring(fileUri, '/', URL_PARTS_COUNT));
            var memStream = new MemoryStream();

            await blob.DownloadToStreamAsync(memStream).ConfigureAwait(false);
            return memStream;
        }

        public async Task DownloadFileByUrlAsync(Uri downloadUri, string destinationFileName)
        {
            using (var webClient = new WebClient())
            {
                await webClient.DownloadFileTaskAsync(downloadUri, destinationFileName).ConfigureAwait(false);
            }
        }

        public async Task<MemoryStream> DownloadFileAsync(string fileUri, string containerName)
        {
            var blobContainer = await _connectionFactory.GetBlobContainer(containerName).ConfigureAwait(false);
            var uri = new Uri(fileUri);
            var directory = blobContainer.GetDirectoryReference(uri.Segments[URL_PARTS_COUNT].TrimEnd('/'));

            var filename = Path.GetFileName(uri.LocalPath);

            var blob = directory.GetBlobReference(filename);

            var memStream = new MemoryStream();

            await blob.DownloadToStreamAsync(memStream);
            memStream.Seek(0, SeekOrigin.Begin);
            return memStream;
        }

        public async Task<MemoryStream> DownloadFileAsyncByFullUrl(string fileUri, string containerName)
        {
            var blobContainer = await _connectionFactory.GetBlobContainer(containerName).ConfigureAwait(false);
            //var uri = new Uri(fileUri);
            //uri.Segments[URL_PARTS_COUNT].TrimEnd('/')
            var blob = blobContainer.GetBlobReference(fileUri);

            var memStream = new MemoryStream();

            await blob.DownloadToStreamAsync(memStream);
            memStream.Seek(0, SeekOrigin.Begin);
            return memStream;
        }

        public async Task<IEnumerable<Uri>> ListAsync(int projectId)
        {
            var blobContainer = await _connectionFactory.GetArtifactsBlobContainer();
            var directory = blobContainer.GetDirectoryReference($"pr_{projectId}");
            var allBlobs = new List<Uri>();

            BlobContinuationToken blobContinuationToken = null;
            do
            {
                var response = await directory.ListBlobsSegmentedAsync(blobContinuationToken);

                await AddFilesUrlsToList(allBlobs, response).ConfigureAwait(false);

                blobContinuationToken = response.ContinuationToken;
            } while (blobContinuationToken != null);

            return allBlobs;
        }

        public async Task<Uri> UploadProjectArchiveAsync(byte[] fileToUpload, string destinationFileNameSufix = "uploaded_project")
        {
            var blobContainer = await _connectionFactory.GetProjectZipsBlobContainer();
            return await UploadAsync(fileToUpload, blobContainer, destinationFileNameSufix);
        }

        public async Task<Uri> UploadGitArchiveAsync(byte[] fileToUpload, string destinationFileNameSufix)
        {
            var blobContainer = await _connectionFactory.GetGitZipsBlobContainer();
            return await UploadAsync(fileToUpload, blobContainer, destinationFileNameSufix);
        }

        public async Task<Uri> UploadArtifactArchiveAsync(byte[] fileToUpload, string destinationFileNameSufix = "uploaded_artifact")
        {
            var blobContainer = await _connectionFactory.GetArtifactsBlobContainer();
            return await UploadAsync(fileToUpload, blobContainer, destinationFileNameSufix);
        }

        public async Task<Uri> UploadArtifactFromPathOnServer(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            var blobContainer = await _connectionFactory.GetArtifactsBlobContainer();
            var fileName = $"{DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss")}_{Path.GetFileName(path)}";
            var blob = blobContainer.GetBlockBlobReference(fileName);
            blob.Properties.ContentType = "application/zip";
            using (var stream = File.OpenRead(path))
            {
                await blob.UploadFromStreamAsync(stream);
            }

            return blob.Uri;
        }

        private async Task<Uri> UploadAsync(byte[] fileToUpload, CloudBlobContainer blobContainer, string destinationFileNameSufix)
        {
            string blobName;

            if(destinationFileNameSufix != "uploaded_project" && destinationFileNameSufix != "uploaded_artifact")
            {
                blobName = $"{destinationFileNameSufix}.zip";
            }
            else
            {
                blobName = $"{DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss")}_{destinationFileNameSufix}.zip";
            }
            var blob = blobContainer.GetBlockBlobReference(blobName);
            blob.Properties.ContentType = "application/zip";
            await blob.UploadFromByteArrayAsync(fileToUpload, 0, fileToUpload.Length).ConfigureAwait(false);
            return blob.Uri;
        }

        private static string GetSubstring(string stringForSubstring, char desiredChar, int charsCount)
        {
            var startingPos = 0;
            for (var i = 0; i < charsCount; i++)
            {
                startingPos = stringForSubstring.IndexOf(desiredChar, startingPos) + 1;
            }

            return stringForSubstring.Substring(startingPos);
        }

        private static async Task<IEnumerable<Uri>> AddFilesUrlsToList(
            ICollection<Uri> uris,
            BlobResultSegment response)
        {
            BlobContinuationToken blobContinuationToken = null;
            do
            {
                foreach (var blob in response.Results)
                {
                    if (blob.GetType() == typeof(CloudBlockBlob))
                    {
                        uris.Add(blob.Uri);
                    }
                    else if (blob is CloudBlobDirectory dir)
                    {
                        await AddFilesUrlsToList(uris, await dir.ListBlobsSegmentedAsync(blobContinuationToken))
                            .ConfigureAwait(false);
                    }
                }

                blobContinuationToken = response.ContinuationToken;
            } while (blobContinuationToken != null);

            return uris;
        }
    }
}
