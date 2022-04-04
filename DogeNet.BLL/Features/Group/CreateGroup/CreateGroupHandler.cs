// <copyright file="CreateGroupHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Group.CreateGroup
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Services.Interfaces;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CreateGroupHandler : IRequestHandler<CreateGroupCommand>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public CreateGroupHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = this.mapper.Map<Group>(request.model);

            this.context.Groups.Add(group);
            await this.context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
