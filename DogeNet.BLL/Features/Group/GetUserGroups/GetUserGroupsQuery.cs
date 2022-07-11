// <copyright file="GetUserGroupsQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.GetUserGroups
{
    using System.Collections.Generic;
    using DogeNet.BLL.Features.Group.GetGroup;
    using MediatR;

    public record GetUserGroupsQuery(int id) : IRequest<List<GroupDetailsModel>>;
}
