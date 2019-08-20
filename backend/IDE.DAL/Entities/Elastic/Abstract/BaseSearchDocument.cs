using Nest;

namespace IDE.DAL.Entities.Elastic.Abstract
{
    [ElasticsearchType(IdProperty = nameof(Id))]
    public abstract class BaseSearchDocument
    {
        public BaseSearchDocument(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
