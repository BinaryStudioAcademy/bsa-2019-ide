using Humanizer;
using IDE.DAL.Entities.NoSql.Abstract;
using IDE.DAL.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;

namespace IDE.DAL.Repositories
{
    public class NoSqlRepository<T> : INoSqlRepository<T> where T : BaseNoSqlModel
    {
        private readonly IMongoCollection<T> _items;

        public NoSqlRepository(IFileStorageDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            var itemsCollectionName = GetItemsCollectionName();
            _items = database.GetCollection<T>(itemsCollectionName);
        }

        public List<T> Get() =>
            _items.Find(item => true).ToList();

        public T Get(string id) =>
            _items.Find<T>(item => item.Id == id).FirstOrDefault();

        public T Create(T item)
        {
            _items.InsertOne(item);
            return item;
        }

        public void Update(string id, T itemIn) =>
            _items.ReplaceOne(item => item.Id == id, itemIn);

        public void Remove(T itemIn) =>
            _items.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _items.DeleteOne(item => item.Id == id);

        private string GetItemsCollectionName()
        {
            var itemClassName = nameof(T);
            var itemsCollectionName = itemClassName.Pluralize();
            return itemsCollectionName;
        }
    }
}
