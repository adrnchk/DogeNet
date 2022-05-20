// <copyright file="ChatManager.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChatManager
    {
        public List<ChatUser> Users { get; } = new();

        public void ConnectUser(string userName, string connectionId)
        {
            var userAlreadyExists = this.GetConnectedUserByName(userName);
            if (userAlreadyExists != null)
            {
                userAlreadyExists.AppendConnection(connectionId);
                return;
            }

            var user = new ChatUser(userName);
            user.AppendConnection(connectionId);
            this.Users.Add(user);
        }

        public bool DisconnectUser(string connectionId)
        {
            var userExists = this.GetConnectedUserById(connectionId);
            if (userExists == null)
            {
                return false;
            }

            if (!userExists.Connections.Any())
            {
                return false; 
            }

            var connectionExists = userExists.Connections.Select(x => x.ConnectionId).First().Equals(connectionId);
            if (!connectionExists)
            {
                return false; 
            }

            if (userExists.Connections.Count() == 1)
            {
                this.Users.Remove(userExists);
                return true;
            }

            userExists.RemoveConnection(connectionId);
            return false;
        }

        private ChatUser? GetConnectedUserById(string connectionId) =>
            this.Users
                .FirstOrDefault(x => x.Connections.Select(c => c.ConnectionId)
                .Contains(connectionId));

        private ChatUser? GetConnectedUserByName(string userName) =>
            this.Users
                .FirstOrDefault(x => string.Equals(
                    x.UserName,
                    userName,
                    StringComparison.CurrentCultureIgnoreCase));
    }
}
