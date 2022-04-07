// <copyright file="CreateGroupCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.CreateGroup
{
    using MediatR;

    public record CreateGroupCommand(CreateGroupModel model) : IRequest;
}
