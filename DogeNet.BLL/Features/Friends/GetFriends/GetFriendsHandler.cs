// <copyright file="GetFriendsHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetFriends
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL;
    using MediatR;

    public class GetFriendsHandler : IRequestHandler<GetFriendsQuery, List<FriendsDetailsModel>>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public GetFriendsHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<FriendsDetailsModel>> Handle(GetFriendsQuery request, CancellationToken cancellationToken)
        {
            var list = this.context.Friends.Where(source => source.UserId == request.userId).ToList();

            var friends = new List<FriendsDetailsModel>();

            foreach (var item in list)
            {
                friends.Add(this.mapper.Map<FriendsDetailsModel>(await this.context.Users.FindAsync(item.FriendId)));
            }

            return friends;
        }
    }
}
