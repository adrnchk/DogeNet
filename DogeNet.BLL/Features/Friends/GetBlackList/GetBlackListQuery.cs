// <copyright file="GetBlackListQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetBlackList
{
    using System.Collections.Generic;
    using MediatR;

    public record GetBlackListQuery(int userId) : IRequest<List<BlackListDetailsModel>>;
}
