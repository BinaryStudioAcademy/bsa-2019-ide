using System.Threading.Tasks;

namespace BuildServer.Interfaces
{
    public interface IAzureService
    {
        Task Upload(string fileName);
        Task Download(string fileName);
    }
}
