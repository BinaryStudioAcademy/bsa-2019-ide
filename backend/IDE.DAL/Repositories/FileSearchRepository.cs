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
     
        public override async Task<ICollection<FileSearch>> SearchAsync(string query, int skip = 0, int take = -1)
        {
            var result = await _client.SearchAsync<FileSearch>(s => s
                // //.Index(_index)
                .Query(q => q
                    .MultiMatch(mm => mm
                    .Type(TextQueryType.PhrasePrefix)
                    .Fields(ff => ff
                        .Field(f => f.Content)
                        .Field(f => f.Name)
                        .Field(f => f.Folder)
                    ).Query(query)
                ))
                //.PostFilter(fi => fi.Match(m => m.Field(f => f.ProjectId > 10)))
            );
                
             

                ////.Query(q => q
                ////    .Bool(b => b
                ////        .Must(mu => mu
                ////            .Match(m => m
                ////                .Field(f => f.Content)
                ////                .Query(query)
                ////            ), mu => mu
                ////            .Match(m => m
                ////                .Field(f => f.Folder)
                ////                .Query(query)
                ////            )
                ////        )
                        //.Filter(fi => fi
                        //    .Match(m => m
                        //        .Field(f => f.ProjectId == 14)
                        //    )
                        //)
            //        )
            //    )
            //);



            //    .MultiMatch(mp => mp
            //        .Query(query)
            //        .Fields(f => f 
            //            .Field(ff => ff.Folder)
            //            .Field(ff => ff.Name)
            //            .Field(ff => ff.Content)
            //))));




            //var result = await _client.SearchAsync<FileSearch>(x => x.Index(_index)            // use search method
            //    .Query(q => q               // define query
            //      .MultiMatch(mp => mp            // of type MultiMatch
            //          .Query(query)           // pass text
            //          .Fields(f => f          // define fields to search against
            //                                  //.Field(ff => ff.Id)
            //              .Field(ff => ff.Id)
            //              .Field(ff => ff.Name)
            //              .Field(ff => ff.Content)
            //    ))));

            // var a = result.HitsMetadata.Hits.Select(h => h.Highlight).ToList();

            return result.Documents.ToList();
        }
    }
}

