using IDE.Common.ModelsDTO.Enums;
using IDE.DAL.Entities.NoSql.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Entities.NoSql
{
    public class FileStructure : BaseNoSqlModel
    {
        public FileStructure()
        {
            NestedFiles = new List<FileStructure>();
        }
        public TreeNodeType Type { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public ICollection<FileStructure> NestedFiles { get; set; }
    }
}
