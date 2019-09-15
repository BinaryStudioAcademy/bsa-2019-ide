using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.Services.SignalR
{
    public class ConnectionsService
    {
        private Dictionary<string, int> userConnectionsIds;

        public ConnectionsService()
        {
            userConnectionsIds = new Dictionary<string, int>();
        }

        public bool ContainsKey(string connectionId)
        {
            return userConnectionsIds.ContainsKey(connectionId);
        }

        public void Add(string connectionId, int userId)
        {
            if(!userConnectionsIds.ContainsKey(connectionId))
                userConnectionsIds.Add(connectionId, userId);
        }

        public int GetUserIdByConnection(string connectionId)
        {
            if (userConnectionsIds.ContainsKey(connectionId))
                return userConnectionsIds[connectionId];
            else
                throw new Exception("It can't be thrown, if it is, its program mistake");
        }

        public void Remove(string connectionId)
        {
            userConnectionsIds.Remove(connectionId);
        }
    }
}
