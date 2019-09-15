using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Storage.Interfaces
{
    public interface IBlobRepository
    {
        Task<Uri> UploadProjectArchiveAsync(byte[] file, string destinationFileNameSufix);
        Task<Uri> UploadArtifactArchiveAsync(byte[] file, string destinationFileNameSufix);
        Task<Uri> UploadGitArchiveAsync(byte[] file, string destinationFileNameSufix);
        Task<Uri> UploadArtifactFromPathOnServer(string path);
        Task DownloadFileByUrlAsync(Uri fileUri, string destinationFileName);
        Task<IEnumerable<Uri>> ListAsync(int projectId);
        Task<MemoryStream> DownloadFileAsync(string fileUri, string containerName);
        Task<MemoryStream> DownloadFileAsyncByFullUrl(string fileUri, string containerName);
        Task DeleteAsync(string fileUri);
    }
}
