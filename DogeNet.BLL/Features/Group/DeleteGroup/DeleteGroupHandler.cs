// <copyright file="DeleteGroupHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.DeleteGroup
{
    using System.Threading;
    using System.Threading.Tasks;
    using DogeNet.DAL;
    using MediatR;

    public class DeleteGroupHandler : IRequestHandler<DeleteGroupCommand>
    {
        private readonly DBContext context;

        public DeleteGroupHandler(DBContext context)
        {
            this.context = context;
        }

        public Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            this.context.Groups.Remove(this.context.Groups.Find(request.id));
            this.context.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
