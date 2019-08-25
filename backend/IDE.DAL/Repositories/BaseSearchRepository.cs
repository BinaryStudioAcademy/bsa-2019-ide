using Elasticsearch.Net;
using IDE.DAL.Entities.Elastic.Abstract;
using IDE.DAL.Factories.Abstractions;
using IDE.DAL.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE.DAL.Repositories
{
    public abstract class BaseSearchRepository<T> : ISearchRepository<T> where T : BaseSearchDocument
    {
        protected string _index;
        protected ElasticClient _client;

        public BaseSearchRepository(ISearchClientFactory searchClientFactory)
        {
        }


        // Create/Delete index

        public virtual async Task<bool> CreateIndex()
        {
            if (!_client.Indices.Exists(_index).Exists)
            {
                var response = await _client.Indices.CreateAsync(
                    _index,
                    c => c
                        .Map<T>(m => m
                            .AutoMap()
                ));

                return response.Acknowledged; //\\ to true and in general maybe void method? and method is required?
            }

            return false;
        }

        public virtual async Task<bool> DeleteIndex()
        {
            DeleteIndexResponse response = null;

            if (_client.Indices.Exists(_index).Exists)
            {
                response = await _client.Indices.DeleteAsync(_index);
            }

            return response.Acknowledged;
        }

        // Add document

        public virtual async Task IndexAsync(T document)
        {
            await _client.IndexAsync(
                document, 
                i => i
                    .Index(_index)
                    .OpType(OpType.Create)
            );
        }

        public virtual async Task IndexManyAsync(IList<T> documents)
        {
            await _client.IndexManyAsync(documents);
        }

        // Update document

        public virtual async Task UpdateAsync(T document)
        {
            await _client.UpdateAsync<T>(
                document.Id, 
                u => u
                    .Index(_index)
                    .Doc(document)
            );
        }

        // Delete document

        public virtual async Task DeleteAsync(string id)
        {
            var response = await _client.DeleteAsync<T>(id, d => d.Index(_index));
        }

        // Search in index

        //should be overridden
        //I didn`t implement these methods because they need document`s property
        public virtual async Task<ICollection<T>> AutoCompleteAsync(string query, int skip = 0, int take = -1)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<ICollection<T>> SearchAsync(string query, int skip = 0, int take = -1)
        {
            throw new NotImplementedException();
        }
    }
}
