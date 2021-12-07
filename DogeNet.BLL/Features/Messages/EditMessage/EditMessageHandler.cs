// <copyright file="EditMessageHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.EditMessage
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Features.Messages.GetMessages;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class EditMessageHandler : IRequestHandler<EditMessageCommand, MessagesDetailsModel>
    {
        private readonly DBContext context;
        private readonly IMapper mapper;

        public EditMessageHandler(DBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<MessagesDetailsModel> Handle(EditMessageCommand request, CancellationToken cancellationToken)
        {
            var message = this.context.Messages.Find(request.model.MessageId);

            message.Text = request.model.Text;
            message.UpdatedAt = DateTime.Now;

            await this.context.SaveChangesAsync();

            return this.mapper.Map<Message,MessagesDetailsModel>(message);
        }
    }
}
