using IDE.DAL.Entities.NoSql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.DAL.Interfaces
{
    public interface IFileRepository : INoSqlRepository<File>
    {
        Task<int> ProjectFilesCount(int projectId);
    }
}
