using IDE.DAL.Entities.Elastic;
using IDE.DAL.Factories.Abstractions;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.DAL.Repositories
{
    class TestSearchRepository : BaseSearchRepository<TestDocument>
    {
        public TestSearchRepository(ISearchClientFactory searchClientFactory) : base(searchClientFactory)
        {
            _index = "test";
            _client = searchClientFactory.CreateClient(_index);
        }

        public override async Task<ICollection<TestDocument>> AutoCompleteAsync(string query, int skip = 0, int take = -1)
        {
            var response = await _client.SearchAsync<TestDocument>(s => s
                           .Index(_index)
                           .Source(so => so
                               .Includes(f => f
                                   .Field(ff => ff.Id)
                                   .Field(ff => ff.Brand)
                               )
                           )
                           .Suggest(su => su
                               .Completion("suggest", cs => cs
                                   .Field(f => f.Suggest)
                                   .Prefix(query)
                                   .Fuzzy(f => f
                                       .Fuzziness(Fuzziness.Auto)
                                   )
                                   .Size(10)
                               )
                           )
                       );

            var suggestions = response.Suggest["suggest"]
                                                .SelectMany(o => o.Options
                                                .Select(opt =>
                                                        new TestDocument(
                                                            opt.Id,
                                                            opt.Source.Brand
                                                        )));
            return suggestions.ToList();
        }

        public override async Task<ICollection<TestDocument>> SearchAsync(string query, int skip = 0, int take = -1)
        {
            var result = await _client.SearchAsync<TestDocument>(x => x.Index(_index)            // use search method
          .Query(q => q               // define query
              .MultiMatch(mp => mp            // of type MultiMatch
                  .Query(query)           // pass text
                  .Fields(f => f          // define fields to search against
                                          //.Field(ff => ff.Id)
                      .Field(ff => ff.Brand)))));
                      //.Field(ff => ff.Content)
                      //.Field(ff => ff.Folder)))));

            return result.Documents.ToList();
        }
    }
}

