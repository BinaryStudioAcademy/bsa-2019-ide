using BuildServer.OperationsResults;
using RabbitMQ.Shared.ModelsDTO.Enums;

namespace BuildServer.Interfaces
{
    public interface IProjectBuilder
    {
        BuildResult Build(string projectName, ProjectLanguageType type);
        string Run(string projectName, ProjectLanguageType type);
    }
}
