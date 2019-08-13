using IDE.DAL.Entities.NoSql.Abstract;
using System;
using System.Collections.Generic;

namespace IDE.DAL.Entities.NoSql
{
    public class ProjectStructure: BaseNoSqlModel
    {
        public ProjectStructure()
        {
            NestedFiles = new List<FileStructure>();
        }
        public ICollection<FileStructure> NestedFiles { get; set; }
    }
}
