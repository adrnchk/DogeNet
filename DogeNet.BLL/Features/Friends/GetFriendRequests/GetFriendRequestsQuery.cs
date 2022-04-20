// <copyright file="GetFriendRequestsQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetFriendRequests
{
    using System.Collections.Generic;
    using MediatR;

    public record GetFriendRequestsQuery(int userId) : IRequest<List<FriendRequestsDetailsModel>>;
}
