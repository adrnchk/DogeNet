// <copyright file="GetFriendRequestsHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetFriendRequests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL;
    using MediatR;

    public class GetFriendRequestsHandler : IRequestHandler<GetFriendRequestsQuery, List<FriendRequestsDetailsModel>>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public GetFriendRequestsHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<FriendRequestsDetailsModel>> Handle(GetFriendRequestsQuery request, CancellationToken cancellationToken)
        {
            var list = this.context.BlackLists.Where(source => source.UserId == request.userId).ToList();

            return this.mapper.Map<List<FriendRequestsDetailsModel>>(list);
        }
    }
}
