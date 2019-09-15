namespace BuildServer.Interfaces
{
    public interface IQueueService
    {
        bool SendBuildMessage(string value);
        bool SendRunMessage(string value);
    }
}
