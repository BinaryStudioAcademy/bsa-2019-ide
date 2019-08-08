using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.DAL.Factories.Abstractions
{
    public interface IAzureBlobConnectionFactory
    {
        Task<CloudBlobContainer> GetArchiveArtifactsBlobContainer();
    }
}
