namespace IDE.DAL.Interfaces
{
    public interface IGitRepository
    {
        void InitRepository(string path);
        void CloneRepository(string url, string path);
        void AddToGitRepository(string path);
        void AddToGitRepository(string path, string fileName);
        void CommitAllChanges(string path, string commitMessage, string authorName, string authorEmail);
        void PushCommits(string path, string branchName, string username, string password);
        string FetchAll(string path, string username, string password);
        void Pull(string path, string branchMane, string authorName, string authorEmail);
        void StashUntracked(string path);

    }
}
