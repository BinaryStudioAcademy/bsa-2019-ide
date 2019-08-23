namespace BuildServer.Interfaces
{
    public interface IAzureService
    {
        void Upload(string fileName);
        void Download(string fileName);
    }
}
