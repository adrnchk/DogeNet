// <copyright file="EditPostCommand.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.EditPost
{
    using DogeNet.BLL.Features.Posts.GetPost;
    using MediatR;

    public record EditPostCommand(EditPostModel model) : IRequest<PostDetailsModel>;
}