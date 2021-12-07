// <copyright file="SendMessageHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.SendMessage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class SendMessageHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly DBContext context;

        private readonly IMapper mapper;

        public SendMessageHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var message = this.mapper.Map<Message>(request.model);

            this.context.Messages.Add(message);
            await this.context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
