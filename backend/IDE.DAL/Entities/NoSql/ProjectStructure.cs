using IDE.DAL.Entities.NoSql.Abstract;
using System;
using System.Collections.Generic;

namespace IDE.DAL.Entities.NoSql
{
    public class ProjectStructure
    {
        public ProjectStructure()
        {
            NestedFiles = new List<FileStructure>();
        }

        public string Id { get; set; }
        public ICollection<FileStructure> NestedFiles { get; set; }
    }
}
