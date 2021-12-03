// <copyright file="MessagesController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Conversations;
    using DogeNet.BLL.Features.Messages;
    using DogeNet.BLL.Features.Messages.DeleteMesage;
    using DogeNet.BLL.Features.Messages.EditMessage;
    using DogeNet.BLL.Features.Messages.GetMessage;
    using DogeNet.BLL.Features.Messages.SendMessage;
    using DogeNet.DAL;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly DBContext context;

        public MessagesController(IMediator mediator, DBContext context)
        {
            this.mediator = mediator;
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessages(int id)
        {
            if (ConversationChecks.ConversationIdValid(this.context, id))
            {
                return this.Ok(await this.mediator.Send(new GetMessageQuery(id)));
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new SendMessageCommand(model)));
            }
            else
            {
                return this.BadRequest(this.ModelState.Values);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditMessage(EditMessageModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new EditMessageCommand(model)));
            }
            else
            {
                return this.BadRequest(this.ModelState.Values);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            if (MessageChecks.MessageIdValid(this.context, id))
            {
                return this.Ok(await this.mediator.Send(new DeleteMessageCommand(id)));
            }
            else
            {
                return this.BadRequest();
            }
        }
    }
}
