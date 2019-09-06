using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IGitService
    {
        Task PullAsync(string projectId, string branchName, int authorId);
        Task CreateCommitAsync(string projectId, string message, int authorId);
        Task PushAsync(string projectId, string branchName, int authorId);

        //Task Clone(int userId);
    }
}
