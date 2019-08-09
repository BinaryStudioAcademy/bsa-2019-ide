using Humanizer;
using IDE.DAL.Entities.NoSql.Abstract;
using IDE.DAL.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.DAL.Repositories
{
    public class NoSqlRepository<T> : INoSqlRepository<T> where T : BaseNoSqlModel
    {
        private readonly IMongoCollection<T> _items;

        public NoSqlRepository(IFileStorageNoSqlDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            var itemsCollectionName = GetItemsCollectionName();
            _items = database.GetCollection<T>(itemsCollectionName);
        }

        public async Task<List<T>> GetAllAsync() =>
            await _items.Find(item => true).ToListAsync();

        public async Task<T> GetByIdAsync(string id) =>
            await _items.Find(item => item.Id == id).FirstOrDefaultAsync();

        public async Task<T> CreateAsync(T item)
        {
            await _items.InsertOneAsync(item);
            return item;
        }

        public async Task UpdateAsync(T itemIn) =>
            await _items.ReplaceOneAsync(item => item.Id == itemIn.Id, itemIn);

        public async Task DeleteAsync(string id) =>
            await _items.DeleteOneAsync(item => item.Id == id);

        private string GetItemsCollectionName()
        {
            var itemClassName = typeof(T).ToString().Split('.').Last();
            var itemsCollectionName = itemClassName.Pluralize();
            return itemsCollectionName;
        }
    }
}
