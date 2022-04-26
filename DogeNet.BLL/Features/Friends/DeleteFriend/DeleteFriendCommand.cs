// <copyright file="DeleteFriendCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.DeleteFriend
{
    using MediatR;

    public record DeleteFriendCommand(DeleteFriendModel model) : IRequest;
}
