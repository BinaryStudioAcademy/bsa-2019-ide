using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace Storage.Interfaces
{
    public interface IAzureBlobConnectionFactory
    {
        Task<CloudBlobContainer> GetArchiveArtifactsBlobContainer();
        Task<CloudBlobContainer> GetDownloadedProjectZipsBlobContainer();
        Task<CloudBlobContainer> GetBlobContainer(string containerNameKey);
    }
}
