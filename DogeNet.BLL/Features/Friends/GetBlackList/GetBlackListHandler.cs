// <copyright file="GetBlackListHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Friends.GetBlackList
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL;
    using MediatR;

    public class GetBlackListHandler : IRequestHandler<GetBlackListQuery, List<BlackListDetailsModel>>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public GetBlackListHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BlackListDetailsModel>> Handle(GetBlackListQuery request, CancellationToken cancellationToken)
        {
            var list = this.context.BlackLists.Where(source => source.UserId == request.userId).ToList();

            return this.mapper.Map<List<BlackListDetailsModel>>(list);
        }
    }
}
