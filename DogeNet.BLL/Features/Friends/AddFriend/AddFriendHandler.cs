// <copyright file="AddFriendHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.AddFriend
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class AddFriendHandler : IRequestHandler<AddFriendCommand>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public AddFriendHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(AddFriendCommand request, CancellationToken cancellationToken)
        {
            if (this.context.FriendRequests.Any(req => req.UserId == request.model.FriendId && req.FriendId == request.model.UserId))
            {
                this.context.Friends.Add(this.mapper.Map<Friend>(request.model));
            }
            else
            {
                this.context.FriendRequests.Add(this.mapper.Map<FriendRequest>(request.model));
            }

            await this.context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
