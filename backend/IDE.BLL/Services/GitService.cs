using IDE.BLL.Interfaces;
using IDE.DAL.Context;
using IDE.DAL.Interfaces;
using LibGit2Sharp;
using Microsoft.EntityFrameworkCore;
using Storage.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class GitService : IGitService
    {
        private readonly IdeContext _context;
        private readonly IGitRepository _gitRepository;
        private readonly IBlobRepository _blobRepository;

        private readonly IProjectStructureService _projectStructureService;

        public GitService(IGitRepository gitRepository, IdeContext context, IBlobRepository blobRepository,IProjectStructureService projectStructureService)
        {
            _context = context;
            _gitRepository = gitRepository;
            _blobRepository = blobRepository;
            _projectStructureService = projectStructureService;
        }

        //public async Task Clone(int userId)
        //{

        //    string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "..\\GitTemp", Guid.NewGuid().ToString());

        //    await _projectStructureService.ProjectStructureForGit("88", tempFolder);
        //    await _blobRepository.DownloadFileByUrlAsync("http://127.0.0.1:10000/devstoreaccount1/gitconteiner/.git.zip", "gitconteiner");

        //    var co = new CloneOptions();
        //    co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = username, Password = password };
        //    Repository.Clone("https://github.com/yMoroziuk/Task-7.CSS-HTML.git", tempFolder + "\\ProjectFolder", co);

        //    _projectStructureService.DeleteTempFolder(tempFolder);

           
        //}

        public async Task PullAsync(string projectId, string branchName, int authorId)
        {

            //create temp folder
            //fetch from origin
            //pull from origin

            var author = await _context.Users.SingleOrDefaultAsync(u => u.Id == authorId);
            //get git credentials
            var project = await _context.Projects.Include(p => p.GitCredential).SingleOrDefaultAsync(p => p.Id == Convert.ToInt32(projectId));

            //var userName = project.GitCredential.Login;
            //var password = project.GitCredential.PasswordHash, PasswordSalt;

            //создание папки сюда
            string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "..\\GitTemp", Guid.NewGuid().ToString());

            await _projectStructureService.ProjectStructureForGit(projectId, tempFolder);
            var memoryStr = await _blobRepository.DownloadFileAsync($"http://127.0.0.1:10000/devstoreaccount1/gitconteiner/{projectId}.zip", "gitconteiner");

            await _projectStructureService.UnzipGitFileAsync(memoryStr, tempFolder + "\\ProjectFolder", $"{projectId}.zip");

            _gitRepository.FetchAll(tempFolder + "\\ProjectFolder", username, password);
            _gitRepository.Pull(tempFolder + "\\ProjectFolder", branchName, author.NickName, author.Email);

            _projectStructureService.ZipGitFileAsync(tempFolder + "\\ProjectFolder\\", projectId);

            byte[] data = File.ReadAllBytes(tempFolder + $"\\ProjectFolder\\{projectId}.zip");

            await _blobRepository.UploadProjectArchiveAsync(data, $"{projectId}");

            _projectStructureService.DeleteTempFolder(tempFolder + "\\ProjectFolder\\.git");

            //await _projectStructureService.UpdateAsync(await _projectStructureService.GetByIdAsync(projectId));

            _projectStructureService.DeleteTempFolder(tempFolder);
        }

        public async Task CreateCommitAsync(string projectId, string message, int authorId)
        {
            //create temp folder
            //add to index
            //commit 

            //нужно будет проверить работу с папками, в которых есть гит
            var author = await _context.Users.SingleOrDefaultAsync(u => u.Id == authorId);

            string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "..\\GitTemp", Guid.NewGuid().ToString());

            await _projectStructureService.ProjectStructureForGit(projectId, tempFolder);
            var memoryStr = await _blobRepository.DownloadFileAsync($"http://127.0.0.1:10000/devstoreaccount1/gitconteiner/{projectId}.zip", "gitconteiner");

            await _projectStructureService.UnzipGitFileAsync(memoryStr, tempFolder + "\\ProjectFolder", $"{projectId}.zip");

            _gitRepository.AddToGitRepository(tempFolder + "\\ProjectFolder");
            _gitRepository.CommitAllChanges(tempFolder + "\\ProjectFolder", message, author.NickName, author.Email);

            _projectStructureService.ZipGitFileAsync(tempFolder + "\\ProjectFolder\\", projectId);

            byte[] data = File.ReadAllBytes(tempFolder + $"\\ProjectFolder\\{projectId}.zip");

            await _blobRepository.UploadProjectArchiveAsync(data, $"{projectId}");

            _projectStructureService.DeleteTempFolder(tempFolder + "\\ProjectFolder\\.git");

            _projectStructureService.DeleteTempFolder(tempFolder);
        }

        public async Task PushAsync(string projectId, string branchName, int authorId)
        {
            //create temp folder
            //push
            var author = await _context.Users.SingleOrDefaultAsync(u => u.Id == authorId);
            //get git credentials
            var project = await _context.Projects.Include(p => p.GitCredential).SingleOrDefaultAsync(p => p.Id == Convert.ToInt32(projectId));
           

            //var userName = project.GitCredential.Login;
            //var password = project.GitCredential.PasswordHash, PasswordSalt;

            string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "..\\GitTemp", Guid.NewGuid().ToString());

            await _projectStructureService.ProjectStructureForGit(projectId, tempFolder);
            var memoryStr = await _blobRepository.DownloadFileAsync($"http://127.0.0.1:10000/devstoreaccount1/gitconteiner/{projectId}.zip", "gitconteiner");

            await _projectStructureService.UnzipGitFileAsync(memoryStr, tempFolder + "\\ProjectFolder", $"{projectId}.zip");

            _gitRepository.PushCommits(tempFolder + "\\ProjectFolder", branchName, username, password);

            _projectStructureService.ZipGitFileAsync(tempFolder + "\\ProjectFolder\\", projectId);

            _projectStructureService.DeleteTempFolder(tempFolder + "\\ProjectFolder\\.git");

            byte[] data = File.ReadAllBytes(tempFolder + $"\\ProjectFolder\\{projectId}.zip");

            await _blobRepository.UploadProjectArchiveAsync(data, $"{projectId}");

            _projectStructureService.DeleteTempFolder(tempFolder);
        }
    }
}
