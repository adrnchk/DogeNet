// <copyright file="DeletePostCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.DeletePost
{
    using MediatR;

    public record DeletePostCommand(int postId) : IRequest;
}