// <copyright file="DeletePostHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Posts.DeletePost
{
    using System.Threading;
    using System.Threading.Tasks;
    using DogeNet.DAL;
    using MediatR;

    public class DeletePostHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly DBContext context;

        public DeletePostHandler(DBContext context)
        {
            this.context = context;
        }

        public Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            this.context.Posts.Remove(this.context.Posts.Find(request.postId));
            this.context.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
