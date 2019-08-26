using IDE.DAL.Entities.Elastic;
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

        public async Task<List<FileSearchResult>> SearchAsync(string query, int projecId, int skip = 0, int take = -1)
        {
            var searchResponce = await _client.SearchAsync<FileSearch>(s => s
                .Index(_index)
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
                    .Fields(
                        fs => fs
                            .Field(f => f.Content)
                                .Type(HighlighterType.Plain)
                                .FragmentSize(20)
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
                       
            var result = searchResponce.Hits.Select(h => new FileSearchResult { FileId = h.Source.Id, FileName = h.Source.Name, Hightlights = h.Highlight }).ToList();

            return result;
        }

        public async Task<ICollection<FileSearch>> FirstFullWorkingSearchAsync(string query, int skip = 0, int take = -1)
        {
            var result = await _client.SearchAsync<FileSearch>(s => s
                //.Sort(so => so.Descending("_score"))
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

            // Try to take row between \n
            //.Highlight(h => h
            //        .Fields(
            //            fs => fs
            //                .Field(f => f.Content)
            //                    //.NumberOfFragments(-1)
            //                    //.FragmentOffset(5)
            //                    ////.ForceSource(true)
            //                    ////.HighlightQuery()
            //                    ////.MatchedFields(mf => mf.Field(f => f.Content))
            //                    //.TagsSchema(HighlighterTagsSchema.Styled) 
            //                    //.Order(HighlighterOrder.Score)
            //                    //.Fragmenter(HighlighterFragmenter.Simple)
            //                    //.FragmentSize(10)
            //                    .Type(HighlighterType.Fvh)
            //                    .BoundaryCharacters(".,!? \t\n")
            //                    //.BoundaryMaxScan(20)
            //                    .PreTags("<b style='color:red'>")
            //                    .PostTags("</b>"),
            //            fs => fs
            //                .Field(f => f.Name)
            //                    .PreTags("<b style='color:yellow'>")
            //                    .PostTags("</b>"),
            //            fs => fs
            //                .Field(f => f.Folder)
            //                    .PreTags("<b style='color:orange'>")
            //                    .PostTags("</b>")
            //        )
            //    )

            return result.Documents.ToList();
        }
    }
}

