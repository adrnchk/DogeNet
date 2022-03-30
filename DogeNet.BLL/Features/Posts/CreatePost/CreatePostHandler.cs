// <copyright file="CreatePostHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.CreatePost
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Services.Interfaces;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class CreatePostHandler : IRequestHandler<CreatePostCommand>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public CreatePostHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = this.mapper.Map<Post>(request.model);

            this.context.Posts.Add(post);
            await this.context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
