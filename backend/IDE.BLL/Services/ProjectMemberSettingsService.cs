using IDE.BLL.Interfaces;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class ProjectMemberSettingsService : IProjectMemberSettingsService
    {
        private readonly IdeContext _context;

        public ProjectMemberSettingsService(IdeContext context)
        {
            _context = context;
        }

        public async Task SetFavouriteProject(int projectId, int userId)
        {
            var contextFP = _context.FavouriteProjects.FirstOrDefault(x => x.UserId == userId && x.ProjectId == projectId);
            if (contextFP != null)
            {
                _context.FavouriteProjects.Remove(contextFP);
            }
            else
            {
                var fp = new FavouriteProjects
                {
                    ProjectId = projectId,
                    UserId = userId
                };
                _context.FavouriteProjects.Add(fp);
            }
            await _context.SaveChangesAsync();
        }
    }
}
