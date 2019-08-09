using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IDE.DAL.Entities.NoSql.Abstract
{
    public abstract class BaseNoSqlModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
