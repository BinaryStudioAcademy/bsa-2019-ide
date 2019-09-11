using IDE.DAL.Interfaces;
using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IDE.DAL.Repositories
{
    public class GitRepository : IGitRepository
    {
        public void InitRepository(string path)
        {
            Repository.Init(path);
        }

        public void CloneRepository(string url, string path)
        {
            Repository.Clone(url, path);
        }

        public void AddToGitRepository(string path)
        {
            using (var repo = new Repository(path))
            {
                Commands.Stage(repo, "*");
            }
        }

        public void AddToGitRepository(string path, string fileName)
        {
            using (var repo = new Repository(path))
            {
                repo.Index.Add(fileName);
                repo.Index.Write();
            }
        }

        public void StashUntracked(string path)
        {
            using (var repo = new Repository(path))
            {

                var t = repo.RetrieveStatus().Where(s => 
                (s.State & FileStatus.ModifiedInWorkdir) != 0 ||
                (s.State & FileStatus.DeletedFromWorkdir) != 0).ToList();

                foreach (var item in t)
                {
                    repo.Index.Remove(item.FilePath);
                }
            }
        }

        public void CommitAllChanges(string path, string commitMessage, string authorName, string authorEmail)
        {
            using (var repo = new Repository(path))
            {
                var changes = repo.RetrieveStatus();

                if (!changes.IsDirty)
                    return;

                var folder = new DirectoryInfo(path);

                var files = folder.GetFiles("*", SearchOption.AllDirectories).Select(f => f.FullName);

                // Create the committer's signature and commit
                Signature author = new Signature(authorName, authorEmail, DateTimeOffset.Now);
                Signature committer = author;

                // Commit to the repository
                Commit commit = repo.Commit(commitMessage, author, committer);
            }
        }

        public void PushCommits(string path, string branchName, string username, string password)
        {

            try
            {
                using (var repo = new Repository(path))
                {
                    var remote = repo.Network.Remotes["origin"];
                    var options = new PushOptions
                    {
                        CredentialsProvider = (url, user, cred) => new UsernamePasswordCredentials
                        {
                            Username = username,
                            Password = password
                        }
                    };

                    repo.Network.Push(remote, $"refs/heads/{branchName}", options);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:RepoActions:PushChanges " + e.Message);
            }
        }

        public string FetchAll(string path, string username, string password)
        {
            var logMessage = "";

            using (var repo = new Repository(path))
            {
                FetchOptions options = new FetchOptions();
                options.CredentialsProvider = new CredentialsHandler((url, usernameFromUrl, types) =>
                    new UsernamePasswordCredentials()
                    {
                        Username = username,
                        Password = password
                    });

                foreach (Remote remote in repo.Network.Remotes)
                {
                    IEnumerable<string> refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                    Commands.Fetch(repo, remote.Name, refSpecs, options, logMessage);
                }
            }

            return logMessage;
        }

        public void Pull(string path, string branchMane, string authorName, string authorEmail)
        {
            using (var repo = new Repository(path))
            {
                var trackingBranch = repo.Branches[$"remotes/origin/{branchMane}"];

                if (trackingBranch.IsRemote)
                {
                    var branch = repo.Head;
                    repo.Branches.Update(branch, b => b.TrackedBranch = trackingBranch.CanonicalName);
                }

                PullOptions pullOptions = new PullOptions()
                {
                    MergeOptions = new MergeOptions()
                    {
                        FastForwardStrategy = FastForwardStrategy.Default
                    }
                };

                MergeResult mergeResult = Commands.Pull(
                    repo,
                    new Signature(authorName, authorEmail, DateTimeOffset.Now),
                    pullOptions
                );
            }
        }
    }
}
