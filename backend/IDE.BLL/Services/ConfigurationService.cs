using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.Services
{
    public class ConfigurationService
    {
        public readonly int MaxFilesInProjectCount;
        public readonly int MaxFileSize;

        public ConfigurationService(IConfiguration configuration)
        {
            MaxFilesInProjectCount = configuration.GetValue<int>("maxFilesInProject");
            MaxFileSize = configuration.GetValue<int>("maxFileSymbolsCount");
        }
    }
}
