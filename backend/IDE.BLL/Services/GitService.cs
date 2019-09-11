using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.DTO.Git;
using IDE.DAL.Context;
using IDE.DAL.Entities;
using IDE.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Storage.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class GitService : IGitService
    {
        private readonly IdeContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<GitService> _logger;
        private readonly IGitRepository _gitRepository;
        private readonly IBlobRepository _blobRepository;
        private readonly IProjectStructureService _projectStructureService;

        public GitService(
            IdeContext context,
            IGitRepository gitRepository,
            IBlobRepository blobRepository,
            ILogger<GitService> logger,
            IConfiguration configuration,
            IProjectStructureService projectStructureService)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
            _gitRepository = gitRepository;
            _blobRepository = blobRepository;
            _projectStructureService = projectStructureService;
        }

        public async Task Clone(string projectId, string url, int authorId)
        {
            string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "..\\GitTemp", Guid.NewGuid().ToString());

            if (!Directory.Exists(tempFolder + "\\ProjectFolder"))
            {
                Directory.CreateDirectory(tempFolder + "\\ProjectFolder");
            }

            try
            {
                await _projectStructureService.RemoveFilesBeforeCloneAsync(Convert.ToInt32(projectId));

                _gitRepository.CloneRepository(url, tempFolder + "\\ProjectFolder\\");
                _gitRepository.StashUntracked(tempFolder + "\\ProjectFolder");

                await ReturnGitToBlob(tempFolder, projectId);

                //_projectStructureService.DeleteTempFolder(tempFolder + "\\ProjectFolder\\.git");
                File.Delete(tempFolder + $"\\ProjectFolder\\g{projectId}.zip");

                await _projectStructureService.UpdateProjectStructureFromTempFolder(projectId, tempFolder + "\\ProjectFolder", authorId, true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                _logger.LogError(ex.Message);
            }
            finally
            {
                _projectStructureService.DeleteTempFolder(tempFolder);
            }
        }

        public async Task<int> AddGitCredentialsToProject(GitCredentialsDTO gitCredentialsDTO, int authorId)
        {
            var project = await _context.Projects
                .SingleOrDefaultAsync(p => p.Id == Convert.ToInt32(gitCredentialsDTO.ProjectId));

            var gitCredentials = new GitCredential
            {
                Login = gitCredentialsDTO.Login,
                Url = gitCredentialsDTO.Url,
                Provider = gitCredentialsDTO.Provider,
                PasswordHash = gitCredentialsDTO.Password
            };

            project.GitCredential = gitCredentials;
            project.ProjectLink = gitCredentials.Url.Substring(0, gitCredentials.Url.LastIndexOf('.'));

            await _context.GitCredentials.AddAsync(gitCredentials);
            await _context.SaveChangesAsync();

            await Clone(gitCredentialsDTO.ProjectId, project.ProjectLink, authorId);

            return gitCredentials.Id;
        }

        public async Task PullAsync(string projectId, string branchName, int authorId)
        {
            var author = await _context.Users.SingleOrDefaultAsync(u => u.Id == authorId);

            var project = await _context.Projects
                .Include(p => p.GitCredential)
                .SingleOrDefaultAsync(p => p.Id == Convert.ToInt32(projectId));

            var username = project.GitCredential.Login;
            var password = project.GitCredential.PasswordHash;

            string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "..\\GitTemp", Guid.NewGuid().ToString());
            await _projectStructureService.ProjectStructureForGit(projectId, tempFolder);

            try
            {
                await AddGitToFolder(tempFolder, projectId, "gitcontainer");

                File.Delete(tempFolder + $"\\ProjectFolder\\g{projectId}.zip");

                _gitRepository.FetchAll(tempFolder + "\\ProjectFolder", username, password);
                _gitRepository.Pull(tempFolder + "\\ProjectFolder", branchName, project.GitCredential.Login, author.Email);

                _gitRepository.StashUntracked(tempFolder + "\\ProjectFolder");

                await _projectStructureService.UpdateProjectStructureFromTempFolder(projectId, tempFolder + "\\ProjectFolder", authorId, false);

                await ReturnGitToBlob(tempFolder, projectId);

                _projectStructureService.DeleteTempFolder(tempFolder + "\\ProjectFolder\\.git");

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                _logger.LogError(ex.Message);
            }
            finally
            {
                _projectStructureService.DeleteTempFolder(tempFolder);
            }
        }

        public async Task CreateCommitAsync(string projectId, string message, int authorId)
        {
            var author = await _context.Users.SingleOrDefaultAsync(u => u.Id == authorId);

            var project = await _context.Projects
                .Include(p => p.GitCredential)
                .SingleOrDefaultAsync(p => p.Id == Convert.ToInt32(projectId));

            string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "..\\GitTemp", Guid.NewGuid().ToString());            
            await _projectStructureService.ProjectStructureForGit(projectId, tempFolder);

            try
            {
                await AddGitToFolder(tempFolder, projectId, "gitcontainer");

                _gitRepository.AddToGitRepository(tempFolder + "\\ProjectFolder");
                _gitRepository.CommitAllChanges(tempFolder + "\\ProjectFolder", message, project.GitCredential.Login, author.Email);

                await ReturnGitToBlob(tempFolder, projectId);

                _projectStructureService.DeleteTempFolder(tempFolder + "\\ProjectFolder\\.git");

                await _projectStructureService.UpdateAsync(await _projectStructureService.GetByIdAsync(projectId));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                _logger.LogError(ex.Message);
            }
            finally
            {
                _projectStructureService.DeleteTempFolder(tempFolder);
            }
        }

        public async Task PushAsync(string projectId, string branchName, int authorId)
        {
            var author = await _context.Users.SingleOrDefaultAsync(u => u.Id == authorId);

            var project = await _context.Projects
                .Include(p => p.GitCredential)
                .SingleOrDefaultAsync(p => p.Id == Convert.ToInt32(projectId));

            var username = project.GitCredential.Login;
            var password = project.GitCredential.PasswordHash;

            string tempFolder = Path.Combine(Directory.GetCurrentDirectory(), "..\\GitTemp", Guid.NewGuid().ToString());
            await _projectStructureService.ProjectStructureForGit(projectId, tempFolder);

            try
            { 
                await AddGitToFolder(tempFolder, projectId, "gitcontainer");

                _gitRepository.PushCommits(tempFolder + "\\ProjectFolder", branchName, username, password);

                await ReturnGitToBlob(tempFolder, projectId);

                _projectStructureService.DeleteTempFolder(tempFolder + "\\ProjectFolder\\.git");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                _logger.LogError(ex.Message);
            }
            finally
            {
                _projectStructureService.DeleteTempFolder(tempFolder);
            }
        }

        private async Task AddGitToFolder(string tempFolder, string projectId, string container)
        {
            //url
            var memoryStr = await _blobRepository.DownloadFileAsyncByFullUrl($"g{projectId}.zip", container);
            await _projectStructureService.UnzipGitFileAsync(memoryStr, tempFolder + "\\ProjectFolder", $"g{projectId}.zip");
        }

        private async Task ReturnGitToBlob(string tempFolder, string projectId)
        {
            _projectStructureService.ZipGitFileAsync(tempFolder, projectId);
            byte[] data = File.ReadAllBytes(tempFolder + $"\\ProjectFolder\\g{projectId}.zip");
            await _blobRepository.UploadGitArchiveAsync(data, $"g{projectId}");
        }
    }
}
