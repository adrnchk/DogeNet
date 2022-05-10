// <copyright file="EditPostHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.EditPost
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Features.Posts.GetPost;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class EditPostHandler : IRequestHandler<EditPostCommand, PostDetailsModel>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public EditPostHandler(DBContext context,  IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PostDetailsModel> Handle(EditPostCommand request, CancellationToken cancellationToken)
        {
            var post = this.context.Posts.Find(request.model.Id);
            post = this.mapper.Map<EditPostModel, Post>(request.model, post);
            await this.context.SaveChangesAsync();

            return this.mapper.Map<Post, PostDetailsModel>(post);
        }
    }
}
