// <copyright file="GetPostQuery.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.GetPost
{
    using System.Collections.Generic;
    using MediatR;

    public record GetPostQuery(int id) : IRequest<PostDetailsModel>;
}