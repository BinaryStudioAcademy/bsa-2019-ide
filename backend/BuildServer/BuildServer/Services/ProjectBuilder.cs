using BuildServer.Interfaces;
using BuildServer.OperationsResults;
using BuildServer.Services.Builders;
using RabbitMQ.Shared.ModelsDTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildServer.Services
{
    public class ProjectBuilder : IProjectBuilder
    {
        private CSharpConsoleBuilder _cSharpBuilder;
        private TSConsoleBuilder _tsBuilder;
        private GoConsoleBuilder _goBuilder;

        public ProjectBuilder(CSharpConsoleBuilder cSharpBuilder, TSConsoleBuilder tsBuilder, GoConsoleBuilder goBuilder)
        {
            _cSharpBuilder = cSharpBuilder;
            _tsBuilder = tsBuilder;
            _goBuilder = goBuilder;
        }

        public BuildResult Build(string projectName, ProjectLanguageType type)
        {
            switch (type)
            {
                case ProjectLanguageType.CSharpConsoleApp:
                    return _cSharpBuilder.Build(projectName);
                case ProjectLanguageType.GoConsoleApp:
                    return _goBuilder.Build(projectName);
                case ProjectLanguageType.TypeScriptConsoleApp:
                    return _tsBuilder.Build(projectName);
                default:
                    return new BuildResult
                    {
                        Message = "Such language and application type isn't defined"
                    };
            }
        }

        public string Run(string projectName, ProjectLanguageType type, params string[] inputs)
        {
            switch (type)
            {
                case ProjectLanguageType.CSharpConsoleApp:
                    return _cSharpBuilder.Run(projectName, inputs);
                case ProjectLanguageType.GoConsoleApp:
                    return _goBuilder.Run(projectName);
                case ProjectLanguageType.TypeScriptConsoleApp:
                    return _tsBuilder.Run(projectName);
                default:
                    return "Such language and application type isn't defined";
            }
        }
    }
}
