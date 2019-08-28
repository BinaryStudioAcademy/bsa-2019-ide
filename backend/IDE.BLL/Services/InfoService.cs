using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Common;
using IDE.DAL.Context;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class InfoService : IInfoService
    {
        public IdeContext _context;
        INoSqlRepository<File> _fileRepository;

        public InfoService(IdeContext context, INoSqlRepository<File> fileRepository)
        {
            _context = context;
            _fileRepository = fileRepository;

        }

        public async Task<WebSiteInfo> GetInfo()
        {
            return new WebSiteInfo()
            {
                FilesCount = await _fileRepository.GetItemsCount(),
                CollaboratorsCount = _context.ProjectMembers.LongCount(),
                ProjectsCount = _context.Projects.LongCount(),
                UsersCount = _context.Users.LongCount()
            };
        }
    }
}
