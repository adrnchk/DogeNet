// <copyright file="DeleteGroupCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.DeleteGroup
{
    using MediatR;

    public record DeleteGroupCommand(int id) : IRequest;
}