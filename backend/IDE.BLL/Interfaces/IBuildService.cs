using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IBuildService
    {
        Task BuildDotNetProject(int projectId);
    }
}
