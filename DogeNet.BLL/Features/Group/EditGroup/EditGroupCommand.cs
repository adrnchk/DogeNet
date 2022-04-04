// <copyright file="EditGroupCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.EditGroup
{
    using MediatR;

    public record EditGroupCommand(EditGroupModel model) : IRequest;
}