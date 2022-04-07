// <copyright file="GetGroupHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.GetGroup
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class GetGroupHandler : IRequestHandler<GetGroupQuery, GroupDetailsModel>
    {
        private readonly DBContext context;
        private readonly IMapper mapper;

        public GetGroupHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GroupDetailsModel> Handle(GetGroupQuery request, CancellationToken cancellationToken)
        {
            var group = await this.context.Groups.FindAsync(request.id);

            return this.mapper.Map<Group, GroupDetailsModel>(group);
        }
    }
}
