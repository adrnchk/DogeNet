// <copyright file="DeleteMessageHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.DeleteMesage
{
    using System.Threading;
    using System.Threading.Tasks;
    using DogeNet.DAL;
    using MediatR;

    public class DeleteMessageHandler : IRequestHandler<DeleteMessageCommand>
    {
        private readonly DBContext context;

        public DeleteMessageHandler(DBContext context)
        {
            this.context = context;
        }

        public Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            this.context.Messages.Remove(this.context.Messages.Find(request.messageId));
            this.context.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
