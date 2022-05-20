// <copyright file="CommunicationHub.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class CommunicationHub : Hub<ICommunicationHub>
    {
        private const string DefaultGroupName = "General";
        private readonly ChatManager chatManager;

        public CommunicationHub(ChatManager chatManager)
            => this.chatManager = chatManager;

        public override async Task OnConnectedAsync()
        {
            var userName = this.Context.User?.Identity?.Name ?? "Anonymous";
            var connectionId = this.Context.ConnectionId;
            this.chatManager.ConnectUser(userName, connectionId);
            await this.Groups.AddToGroupAsync(connectionId, DefaultGroupName);
            await this.UpdateUsersAsync();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var isUserRemoved = this.chatManager.DisconnectUser(this.Context.ConnectionId);
            if (!isUserRemoved)
            {
                await base.OnDisconnectedAsync(exception);
            }

            await this.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, DefaultGroupName);
            await this.UpdateUsersAsync();
            await base.OnDisconnectedAsync(exception);
        }

        public async Task UpdateUsersAsync()
        {
            var users = this.chatManager.Users.Select(x => x.UserName).ToList();
            await this.Clients.All.UpdateUsersAsync(users);
        }

        public async Task SendMessageAsync(string userName, string message) =>
            await this.Clients.All.SendMessageAsync(userName, message);
    }
}
