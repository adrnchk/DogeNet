// <copyright file="ICommunicationHub.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Hubs
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommunicationHub
    {
        Task SendMessageAsync(string userName, string message);

        Task EditMessageAsync(string userName, int messageId, string message);

        Task DeleteMessageAsync(string userName, int messageId);

        Task UpdateUsersAsync(IEnumerable<string> users);
    }
}
