using IDE.DAL.Entities.Elastic.Abstract;
using Nest;

namespace IDE.DAL.Entities.Elastic
{
    public class TestDocument : BaseSearchDocument
    {
        [Text(Name = "brand")]
        public string Brand { get; set; }
        public CompletionField Suggest { get; set; }

        public TestDocument(string id, string brand) : base(id)
        {
            Brand = brand;

            Suggest = new CompletionField
            {
                Input = new[]
                {
                   Brand
                }
            };
        }
    }
}
