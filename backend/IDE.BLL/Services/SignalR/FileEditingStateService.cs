using IDE.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDE.BLL.Services.SignalR
{
    public class FileEditingStateService: IFileEditStateService
    {
        private List<FileEdit> editingFiles;

        public FileEditingStateService()
        {
            editingFiles = new List<FileEdit>();
        }

        public bool AddFileToEdit(int userId, string fileId, int projectId)
        {
            if(ContainsFile(fileId))
            {
                return false;
            }
            editingFiles.Add(new FileEdit()
            {
                UserId = userId,
                FileId = fileId,
                ProjectId = projectId
            });
            return true;
        }

        public bool ContainsFile(string fileId)
        {
            return editingFiles.Select(f => f.FileId).Contains(fileId);
        }

        public bool RemoveFile(string fileId, int userId)
        {
            var file = editingFiles.Find(f => f.FileId == fileId);
            if (file == null)
                return false;
            if (userId != file.UserId)
                return false;
            editingFiles.Remove(file);
            return true;
        }

        public bool RemoveUserFiles(int userId)
        {
            var files = editingFiles.Where(f => f.UserId == userId).ToArray();
            if (files == null)
                return false;
            for(int i = files.Count(); i < 0; i--)
                editingFiles.Remove(files[i]);
            return true;
        }

        public int? GetFileProjectId(string fileId)
        {
            var file = editingFiles.Find(f => f.FileId == fileId);
            return file?.ProjectId;
        }

        public FileEdit[] GetProjectFiles(int projectId)
        {
            return editingFiles.Where(f => f.ProjectId == projectId).ToArray();
        }

        public FileEdit[] GetUserFiles(int userId)
        {
            return editingFiles.Where(f => f.UserId == userId).ToArray();
        }
    }

    public class FileEdit
    {
        public string FileId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
