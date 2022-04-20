// <copyright file="GetFriendsQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetFriends
{
    using System.Collections.Generic;
    using MediatR;

    public record GetFriendsQuery(int userId) : IRequest<List<FriendsDetailsModel>>;
}
