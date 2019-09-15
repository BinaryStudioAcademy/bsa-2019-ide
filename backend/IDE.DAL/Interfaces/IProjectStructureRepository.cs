using IDE.DAL.Entities.NoSql;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IDE.DAL.Interfaces
{
    public interface IProjectStructureRepository
    {
        Task<List<ProjectStructure>> GetAllAsync(Expression<Func<ProjectStructure, bool>> findExpression);
        Task<ProjectStructure> GetByIdAsync(string id);
        Task<ProjectStructure> CreateAsync(ProjectStructure item);
        Task UpdateAsync(ProjectStructure item);
        Task DeleteAsync(string id);
    }
}
