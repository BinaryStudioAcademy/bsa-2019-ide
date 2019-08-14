using Humanizer;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IDE.DAL.Repositories
{
    public class ProjectStructureRepository : IProjectStructureRepository
    {
        private readonly IMongoCollection<ProjectStructure> _items;

        public ProjectStructureRepository(IFileStorageNoSqlDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            var itemsCollectionName = GetItemsCollectionName();
            _items = database.GetCollection<ProjectStructure>(itemsCollectionName);
        }

        public async Task<List<ProjectStructure>> GetAllAsync(Expression<Func<ProjectStructure, bool>> findExpression)
        {
            return await _items.Find(findExpression).ToListAsync();
        }

        public async Task<ProjectStructure> GetByIdAsync(string id)
        {
            return await _items.Find(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ProjectStructure> CreateAsync(ProjectStructure item)
        {
            await _items.InsertOneAsync(item);
            return item;
        }

        public async Task UpdateAsync(ProjectStructure itemIn)
        {
            await _items.ReplaceOneAsync(item => item.Id == itemIn.Id, itemIn);
        }

        public async Task DeleteAsync(string id)
        {
            await _items.DeleteOneAsync(item => item.Id == id);
        }

        private static string GetItemsCollectionName()
        {
            var itemClassName = typeof(ProjectStructure).ToString().Split('.').Last();
            var itemsCollectionName = itemClassName.Pluralize();
            return itemsCollectionName;
        }
    }
}
