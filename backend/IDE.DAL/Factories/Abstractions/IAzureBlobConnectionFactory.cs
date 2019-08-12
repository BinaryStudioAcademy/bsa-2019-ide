using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;

namespace IDE.DAL.Factories.Abstractions
{
    public interface IAzureBlobConnectionFactory
    {
        Task<CloudBlobContainer> GetArchiveArtifactsBlobContainer();
    }
}
