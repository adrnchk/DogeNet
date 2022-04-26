// <copyright file="AddFriendCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.AddFriend
{
    using MediatR;

    public record AddFriendCommand(AddFriendModel model) : IRequest;
}
