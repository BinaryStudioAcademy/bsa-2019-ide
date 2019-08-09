using IDE.DAL.Entities.NoSql.Abstract;
using System.Collections.Generic;

namespace IDE.DAL.Interfaces
{
    public interface INoSqlRepository<T> where T : BaseNoSqlModel
    {
        List<T> Get();
        T Get(string id);
        T Create(T item);
        void Update(string id, T itemIn);
        void Remove(T itemIn);
        void Remove(string id);
    }
}
