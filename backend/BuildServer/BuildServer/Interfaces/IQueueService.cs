namespace BuildServer.Interfaces
{
    public interface IQueueService
    {
        bool SendMessage(string value);
    }
}
