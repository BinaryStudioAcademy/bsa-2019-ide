using IDE.DAL.Entities.Elastic.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.DAL.Interfaces
{
    public interface ISearchRepository<T> where T : BaseSearchDocument
    {
        #region Add document/documents in the index
        Task IndexAsync(T document);

        Task IndexAsync(IList<T> documents);
        #endregion

        #region Search for documents in the index
        Task<ICollection<T>> SearchAsync(string query, int skip = 0, int take = -1);

        Task<ICollection<T>> AutoCompleteAsync(string query, int skip = 0, int take = -1);
        #endregion

        #region Update document in the index
        Task UpdateAsync(T document);
        #endregion

        #region Delete document from index
        Task DeleteAsync(string id);
        #endregion

        #region Create/Delete Index
        Task<bool> CreateIndex();

        Task<bool> DeleteIndex();
        #endregion
    }
}
