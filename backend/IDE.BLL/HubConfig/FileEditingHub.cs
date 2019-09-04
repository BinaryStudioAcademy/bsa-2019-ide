using IDE.BLL.Interfaces;
using IDE.BLL.Services.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.HubConfig
{
    public class FileEditingHub: Hub
    {
        private readonly IFileEditStateService _files;
        private readonly ConnectionsService _connections;

        public FileEditingHub(IFileEditStateService files, ConnectionsService connections) 
        {
            _files = files;
            _connections = connections;
        }

        public async Task Connect(int userId, int projectId) // connection
        {
            if (!_connections.ContainsKey(Context.ConnectionId))
            {
                _connections.Add(Context.ConnectionId, userId);
                await ConnectToProject(projectId);
            }
        }
        private async Task ConnectToProject(int projectId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, projectId.ToString());
        }

        public async Task OpenFile(string fileId, int projectId) // open file
        {
            var userId = _connections.GetUserIdByConnection(Context.ConnectionId);
            //await Groups.AddToGroupAsync(Context.ConnectionId, fileId);
            _files.AddFileToEdit(userId, fileId, projectId);
            await SendNewFileState(projectId, fileId);
        }

        public bool GetFileState(string fileId)
        {
            return _files.ContainsFile(fileId);
        }

        public async Task CloseFile(string fileId) // close file
        {
            var userId = _connections.GetUserIdByConnection(Context.ConnectionId);
            var projectId = _files.GetFileProjectId(fileId);
            if (projectId != null)
            {
                await RemoveFile(fileId, userId, (int)projectId).ConfigureAwait(false);
            }
        }

        private async Task RemoveFile(string fileId, int userId, int projectId)
        {
            _files.RemoveFile(fileId, userId);
            await SendNewFileState(projectId, fileId);
        }

        public async Task CloseProject(int projectId) // close project
        {
            var files = _files.GetProjectFiles(projectId);
            var userId = _connections.GetUserIdByConnection(Context.ConnectionId);
            foreach(var f in files)
            {
                await RemoveFile(f.FileId, userId, projectId);
            }
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, projectId.ToString());
        }

        public async Task SendNewFileState(int projectId, string fileId) 
        {
            await Clients.Group(projectId.ToString())
                .SendAsync("changeFileState", fileId, GetFileState(fileId))
                .ConfigureAwait(false);
        }

        public async Task Disconnect() // disconect
        {
            if (_connections.ContainsKey(Context.ConnectionId))
            {
                var connectionId = Context.ConnectionId;
                var userId = _connections.GetUserIdByConnection(connectionId);
                var files = _files.GetUserFiles(userId);
                foreach (var f in files)
                {
                    await RemoveFile(f.FileId, userId, f.ProjectId);
                }
                _connections.Remove(connectionId);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Disconnect();
            await base.OnDisconnectedAsync(exception);
        }
    }
}
