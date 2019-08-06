using IDE.DAL.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDE.BLL.Services.Abstract
{
    public abstract class BaseService<T>
    {
        private protected readonly IdeContext _context;

        public BaseService(IdeContext context)
        {
            _context = context;
        }

        public abstract Task<ICollection<T>> GetAll();
        public abstract Task<T> GetById(int id);
        public abstract Task<T> Create(T entity);
        public abstract Task Update(T entity);
        public abstract Task Delete(int Id);
    }
}
