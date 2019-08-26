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

        //public override async Task<bool> CreateIndex()
        //{
        //    if (!_client.Indices.Exists(_index).Exists)
        //    {
        //        var response = await _client.Indices.CreateAsync(
        //            _index,
        //            c => c
        //                .Map<FileSearch>(m => m
        //                    //.AutoMap()
        //                    .Properties(ps => ps.Text(s => s.Name(n => n.Content).TermVector(TermVectorOption.WithPositionsOffsets))
        //                    .Object<FileSearch>(o => o.Name(n => n.Content).Properties(fps => fps.Text(ft => ft.TermVector(TermVectorOption.WithPositionsOffsets)))))
                            
        //        ));

        //        return response.Acknowledged; //\\ to true and in general maybe void method? and method is required?
        //    }

        //    return false;
        //}

        //public /*override*/ async Task<ICollection<FileSearch>> SearchAsync(string query, int projecId  = 14, int skip = 0, int take = -1)
        public async Task<List<IReadOnlyDictionary<string, IReadOnlyCollection<string>>>> SearchAsync(string query, int projecId = 19, int skip = 0, int take = -1)
        {
            var searchResult = await _client.SearchAsync<FileSearch>(s => s
                // //.Index(_index)
                //.Sort(so => so.Descending("_score"))
                .From(skip)
                .Size(take)
                .Query(q => q
                    .MultiMatch(mm => mm
                        .Type(TextQueryType.PhrasePrefix)
                        .Fields(fs => fs
                            .Field(f => f.Content)
                            .Field(f => f.Name)
                            .Field(f => f.Folder)
                        )                     
                        .Query(query)
                    )
                    && +q.Match(m=> m
                        .Field(f => f.ProjectId)
                        .Query(projecId.ToString())
                    )               
                )
                .Highlight(h => h
                    //.Fields(ff => ff
                    //    .Field("*")
                    //        .PreTags("<b style='color:orange'>")
                    //        .PostTags("</b>")
                    //        //.FragmentSize(50)
                    //        //.Type(HighlighterType.Fvh)
                    //        .Type(HighlighterType.Fvh)
                    //        .BoundaryScanner(BoundaryScanner.Characters)
                    //        //.BoundaryMaxScan(30)
                    //        .BoundaryCharacters("\\n")
                    //        //.BoundaryMaxScan(10)
                    ////.ForceSource()
                    ////.Fragmenter(HighlighterFragmenter.Simple)
                    //)
                    .Fields(
                        fs => fs
                            .Field(f => f.Content)
                                //.NumberOfFragments(-1)
                                //.FragmentOffset(5)
                                ////.ForceSource(true)
                                ////.HighlightQuery()
                                ////.MatchedFields(mf => mf.Field(f => f.Content))
                                //.TagsSchema(HighlighterTagsSchema.Styled) 
                                //.Order(HighlighterOrder.Score)
                                //.Fragmenter(HighlighterFragmenter.Simple)
                                //.FragmentSize(10)
                                .Type(HighlighterType.Fvh)
                                .BoundaryCharacters(".,!? \t\n")
                                //.BoundaryMaxScan(20)
                                .PreTags("<b style='color:red'>")
                                .PostTags("</b>"),
                        fs => fs
                            .Field(f => f.Name)
                                .PreTags("<b style='color:yellow'>")
                                .PostTags("</b>"),
                        fs => fs
                            .Field(f => f.Folder)
                                .PreTags("<b style='color:orange'>")
                                .PostTags("</b>")
                    )
                )
            );



            List<IReadOnlyDictionary<string, IReadOnlyCollection<string>>> res = searchResult.Hits.Select(h => h.Highlight).ToList();
            //var b = a[0]["content"].ToList();
            //var c = b[0];

            return res;
        }

        public async Task<ICollection<FileSearch>> FirstFullWorkingSearchAsync(string query, int skip = 0, int take = -1)
        {
            var result = await _client.SearchAsync<FileSearch>(s => s
                .Query(q => q
                    .MultiMatch(mm => mm
                        .Type(TextQueryType.PhrasePrefix)
                        .Fields(ff => ff
                            .Field(f => f.Content)
                            .Field(f => f.Name)
                            .Field(f => f.Folder)
                        )
                        .Query(query)
                    )
                    && +q.Match(m => m
                        .Field(f => f.ProjectId)
                        .Query("7")
                    )
                )
                .Highlight(h => h
                    .Fields(ff => ff
                        .Field("*")
                            .PreTags("<b style='color:orange'>")
                            .PostTags("</b>")
                    )
                )
            );

            return result.Documents.ToList();
        }
    }
}

