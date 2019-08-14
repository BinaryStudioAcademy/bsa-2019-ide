using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IProjectMemberSettingsService
    {
        Task SetFavouriteProject(int projectId, int userId);
    }
}
