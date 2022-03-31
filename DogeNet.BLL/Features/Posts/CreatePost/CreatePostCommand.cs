// <copyright file="CreatePostCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.CreatePost
{
    using MediatR;

    public record CreatePostCommand(CreatePostModel model) : IRequest;
}
