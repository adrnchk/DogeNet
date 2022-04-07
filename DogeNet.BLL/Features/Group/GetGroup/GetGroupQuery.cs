// <copyright file="GetGroupQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.GetGroup
{
    using MediatR;

    public record GetGroupQuery(int id) : IRequest<GroupDetailsModel>;
}