using IDE.BLL.Services.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.Interfaces
{
    public interface IFileEditStateService
    {
        bool AddFileToEdit(int userId, string fileId, int projectId);
        bool ContainsFile(string fileId);
        bool RemoveFile(string fileId, int userId);
        bool RemoveUserFiles(int userId);
        int? GetFileProjectId(string fileId);
        FileEdit[] GetProjectFiles(int projectId);
        FileEdit[] GetUserFiles(int userId);
    }
}
