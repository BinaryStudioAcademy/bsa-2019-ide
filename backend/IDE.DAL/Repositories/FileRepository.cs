using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.DAL.Repositories
{
    public class FileRepository : NoSqlRepository<File>, IFileRepository
    {
        public FileRepository(IFileStorageNoSqlDbSettings settings) : base(settings) { }

        public async Task<int> ProjectFilesCount(int projectId)
        {
            var filter = new BsonDocument("ProjectId", projectId);

            return (int)(await _items.CountDocumentsAsync(filter));
            throw new NotImplementedException();
        }
    }
}
