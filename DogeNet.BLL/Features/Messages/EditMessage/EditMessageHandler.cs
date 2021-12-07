// <copyright file="EditMessageHandler.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.BLL.Features.Messages.EditMessage
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.DAL;
    using DogeNet.DAL.Models;
    using MediatR;

    public class EditMessageHandler : IRequestHandler<EditMessageCommand, Message>
    {
        private readonly DBContext context;

        public EditMessageHandler(DBContext context)
        {
            this.context = context;
        }

        public async Task<Message> Handle(EditMessageCommand request, CancellationToken cancellationToken)
        {
            var message = this.context.Messages.Find(request.model.MessageId);

            message.Text = request.model.Text;
            message.UpdatedAt = DateTime.Now;

            this.context.SaveChanges();

            return message;
        }
    }
}
