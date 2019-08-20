using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Factories.Abstractions
{
    public interface ISearchClientFactory
    {
        ElasticClient CreateClient(string index);
    }
}
