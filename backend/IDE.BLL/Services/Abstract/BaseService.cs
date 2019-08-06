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
    }
}
