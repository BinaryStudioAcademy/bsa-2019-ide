using IDE.DAL.Entities.NoSql.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.DAL.Interfaces
{
    public interface INoSqlRepository<T> where T : BaseNoSqlModel
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(string id);
    }
}
