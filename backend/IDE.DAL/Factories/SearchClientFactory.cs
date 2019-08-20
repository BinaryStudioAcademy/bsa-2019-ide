using IDE.DAL.Factories.Abstractions;
using Nest;
using System;

namespace IDE.DAL.Factories
{
    public class SearchClientFactory : ISearchClientFactory
    {
        private string url;

        public SearchClientFactory(string connection)
        {
            url = connection;
        }

        public ElasticClient CreateClient(string index)
        {
            var connectionSettings =
               new ConnectionSettings(new Uri(url));//"http://localhost:9200"

            connectionSettings.DefaultIndex(index);

            return new ElasticClient(connectionSettings);
        }
    }
}
