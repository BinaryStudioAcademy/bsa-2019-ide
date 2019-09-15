using IDE.DAL.Entities.Elastic.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.DAL.Interfaces
{
    public interface ISearchRepository<T> where T : BaseSearchDocument
    {
        Task IndexAsync(T document);

        Task IndexManyAsync(IList<T> documents);

        //Task<ICollection<T>> SearchAsync(string query, int skip = 0, int take = -1);

        //Task<ICollection<T>> AutoCompleteAsync(string query, int skip = 0, int take = -1);

        Task UpdateAsync(T document);

        Task DeleteAsync(string id);

        Task<bool> CreateIndex();

        Task<bool> DeleteIndex();
    }
}
