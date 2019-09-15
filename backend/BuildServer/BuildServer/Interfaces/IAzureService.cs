using System;
using System.Threading.Tasks;

namespace BuildServer.Interfaces
{
    public interface IAzureService
    {
        Task<Uri> Upload(string fileName);
        Task Download(Uri downloadUri, string fileName);
    }
}