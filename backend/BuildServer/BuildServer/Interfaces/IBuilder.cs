namespace BuildServer.Interfaces
{
    public interface IBuilder
    {
        string Build(string projectName);
        string Execute(string projectName);
        string Run(string projectName);
    }
}
