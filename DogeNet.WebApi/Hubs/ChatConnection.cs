// <copyright file="ChatConnection.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Hubs
{
    using System;

    public class ChatConnection
    {
        public DateTime ConnectedAt { get; set; }

        public string ConnectionId { get; set; } = null!;
    }
}
