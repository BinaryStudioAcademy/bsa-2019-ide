using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace Storage.Interfaces
{
    public interface IAzureBlobConnectionFactory
    {
        Task<CloudBlobContainer> GetArtifactsBlobContainer();
        Task<CloudBlobContainer> GetProjectZipsBlobContainer();
        Task<CloudBlobContainer> GetBlobContainer(string containerNameKey);
    }
}
