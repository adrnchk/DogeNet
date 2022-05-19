// <copyright file="ChatUser.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChatUser
    {
        private readonly List<ChatConnection> connections;

        public ChatUser(string userName)
        {
            this.UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            this.connections = new List<ChatConnection>();
        }

        public string UserName { get; }

        public DateTime? ConnectedAt
        {
            get
            {
                if (this.Connections.Any())
                {
                    return this.Connections
                        .OrderByDescending(x => x.ConnectedAt)
                        .Select(x => x.ConnectedAt)
                        .First();
                }

                return null;
            }
        }

        public IEnumerable<ChatConnection> Connections => this.connections;

        public void AppendConnection(string connectionId)
        {
            if (connectionId == null)
            {
                throw new ArgumentNullException(nameof(connectionId));
            }

            var connection = new ChatConnection
            {
                ConnectedAt = DateTime.UtcNow,
                ConnectionId = connectionId,
            };

            this.connections.Add(connection);
        }

        public void RemoveConnection(string connectionId)
        {
            if (connectionId == null)
            {
                throw new ArgumentNullException(nameof(connectionId));
            }

            var connection = this.connections.SingleOrDefault(x => x.ConnectionId.Equals(connectionId));
            if (connection == null)
            {
                return;
            }
            this.connections.Remove(connection);
        }
    }
}
