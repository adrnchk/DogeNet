// <copyright file="GetUserGroupsHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.GetUserGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Features.Group.GetGroup;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class GetUserGroupsHandler: IRequestHandler<GetUserGroupsQuery,List<GroupDetailsModel>>
    {
        private readonly DBContext context;
        private readonly IMapper mapper;

        public GetUserGroupsHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<GroupDetailsModel>> Handle(GetUserGroupsQuery request, CancellationToken cancellationToken)
        {
            var groupsParticipant = this.context.GroupParticipants.Where(a => a.UserId == request.id).ToList();
            var groups = new List<DAL.Models.Group>();

            foreach (var el in groupsParticipant)
            {
               groups.Add(this.context.Groups.Find(el.GroupId));
            }

            return this.mapper.Map<List<DAL.Models.Group>, List<GroupDetailsModel>>(groups);
        }
    }
}
