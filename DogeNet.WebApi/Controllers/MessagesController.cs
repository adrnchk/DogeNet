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
    using DogeNet.BLL.Features.Messages.GetMessages;
    using DogeNet.BLL.Features.Messages.SendMessage;
    using DogeNet.DAL;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator mediator;

        public MessagesController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(List<MessagesDetailsModel>))]
        public async Task<IActionResult> GetMessages(int id) =>
            this.Ok(await this.mediator.Send(new GetMessagesQuery(id)));

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageModel model) =>
            this.Ok(await this.mediator.Send(new SendMessageCommand(model)));

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(MessagesDetailsModel))]
        public async Task<IActionResult> EditMessage(EditMessageModel model) => 
            this.Ok(await this.mediator.Send(new EditMessageCommand(model)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id) => 
            this.Ok(await this.mediator.Send(new DeleteMessageCommand(id)));
    }
}
