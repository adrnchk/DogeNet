// <copyright file="EditGroupHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.EditGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Features.Group.GetGroup;
    using DogeNet.BLL.Services.Interfaces;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class EditGroupHandler
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public EditGroupHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GroupDetailsModel> Handle(EditGroupCommand request, CancellationToken cancellationToken)
        {
            var group = this.context.Groups.Find(request.model.Id);
            group = this.mapper.Map<EditGroupModel, Group>(request.model, group);
            await this.context.SaveChangesAsync();

            return this.mapper.Map<Group, GroupDetailsModel>(group);
        }
    }
}
