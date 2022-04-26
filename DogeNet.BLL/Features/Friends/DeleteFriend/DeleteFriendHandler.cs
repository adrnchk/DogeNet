// <copyright file="DeleteFriandHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.DeleteFriend
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using DogeNet.DAL;
    using MediatR;

    public class DeleteFriendHandler : IRequestHandler<DeleteFriendCommand>
    {

        private readonly DBContext context;

        public DeleteFriendHandler(DBContext context)
        {
            this.context = context;
        }

        public Task<Unit> Handle(DeleteFriendCommand request, CancellationToken cancellationToken)
        {
            var list = this.context.Friends.Where(source =>
            (source.UserId == request.model.UserId && source.FriendId == request.model.FriendId) ||
            (source.UserId == request.model.FriendId && source.FriendId == request.model.UserId));

            foreach (var item in list)
            {
                this.context.Friends.Remove(item);
            }

            this.context.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
