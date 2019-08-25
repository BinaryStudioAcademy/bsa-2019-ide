using IDE.DAL.Entities.Elastic;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Factories.Abstractions;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.DAL.Repositories
{
    public class FileSearchRepository : BaseSearchRepository<FileSearch>
    {
        public FileSearchRepository(ISearchClientFactory searchClientFactory) : base(searchClientFactory)
        {
            _index = "files";
            _client = searchClientFactory.CreateClient(_index);
        }
     
        public override async Task<ICollection<FileSearch>> SearchAsync(string query, int skip = 0, int take = -1) // не используется
        {
            var result = await _client.SearchAsync<FileSearch>(x => x.Index(_index)            // use search method
            .Query(q => q               // define query
              .MultiMatch(mp => mp            // of type MultiMatch
                  .Query(query)           // pass text
                  .Fields(f => f          // define fields to search against
                                          //.Field(ff => ff.Id)
                      .Field(ff => ff.Id)
                      .Field(ff => ff.Name)
                      .Field(ff => ff.Content)
            ))));


            return result.Documents.ToList();
        }
    }
}

