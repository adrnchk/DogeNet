// <copyright file="GetPostHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.GetPost
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class GetPostHandler : IRequestHandler<GetPostQuery, PostDetailsModel>
    {
        private readonly DBContext context;
        private readonly IMapper mapper;

        public GetPostHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PostDetailsModel> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = await this.context.Posts.FindAsync(request.id);

            return this.mapper.Map<Post, PostDetailsModel>(post);
        }
    }
}
