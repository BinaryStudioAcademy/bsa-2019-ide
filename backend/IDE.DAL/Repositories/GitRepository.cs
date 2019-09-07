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
        //fetch -> pull, add -> commit, push
        //private readonly string _repoSource;
        //private readonly UsernamePasswordCredentials _credentials;
        //private readonly DirectoryInfo _localFolder;

        //public GitRepository(string username, string password, string gitRepoUrl, string localFolder)
        //{
        //    var folder = new DirectoryInfo(localFolder);

        //    if (!folder.Exists)
        //    {
        //        throw new Exception(string.Format("Source folder '{0}' does not exist.", _localFolder));
        //    }

        //    _localFolder = folder;

        //    _credentials = new UsernamePasswordCredentials
        //    {
        //        Username = username,
        //        Password = password
        //    };

        //    _repoSource = gitRepoUrl;
        //}

        public void InitRepository(string path)
        {
            Repository.Init(path);
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

            /*
            using (var repo = new Repository(_localFolder.FullName))
            {
                var remote = repo.Network.Remotes.FirstOrDefault(r => r.Name == remoteName);
                if (remote == null)
                {
                    repo.Network.Remotes.Add(remoteName, _repoSource);
                    remote = repo.Network.Remotes.FirstOrDefault(r => r.Name == remoteName);
                }

                var options = new PushOptions
                {
                    CredentialsProvider = (url, usernameFromUrl, types) => _credentials
                };

                repo.Network.Push(remote, branchName, options);
            }
            */
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

        //public string CheckoutBranch(string branchName)
        //{
        //    using (var repo = new Repository(_repoSource))
        //    {
        //        var trackingBranch = repo.Branches[branchName];

        //        if (trackingBranch.IsRemote)
        //        {
        //            branchName = branchName.Replace("origin/", string.Empty);

        //            var branch = repo.CreateBranch(branchName, trackingBranch.Tip);
        //            repo.Branches.Update(branch, b => b.TrackedBranch = trackingBranch.CanonicalName);
        //            Commands.Checkout(repo, branch, new CheckoutOptions { CheckoutModifiers = CheckoutModifiers.Force });
        //        }
        //        else
        //        {
        //            Commands.Checkout(repo, trackingBranch, new CheckoutOptions { CheckoutModifiers = CheckoutModifiers.Force });
        //        }

        //        return branchName;
        //    }
        //}

        //string remoteName, string localBranchName, string remoteBranchName
        public void Pull(string path, string branchMane, string authorName, string authorEmail)
        {
            using (var repo = new Repository(path))
            {
                var trackingBranch = repo.Branches[$"remotes/origin/{branchMane}"];

                if (trackingBranch.IsRemote) // even though I dont want to set tracking branch like this
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
