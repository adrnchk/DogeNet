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

        private readonly ILogger<MessagesController> logger;

        private readonly DBContext context;

        public MessagesController(IMediator mediator, DBContext context, ILogger<MessagesController> logger)
        {
            this.mediator = mediator;
            this.context = context;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(List<MessagesDetailsModel>))]
        public async Task<IActionResult> GetMessages(int id)
        {
            if (ConversationChecks.ConversationIdValid(this.context, id))
            {
                try
                {
                    var result = await this.mediator.Send(new GetMessagesQuery(id));
                    this.logger.LogInformation($"command: {typeof(GetMessagesQuery).Name}");
                    return this.Ok(result);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"command: {typeof(GetMessagesQuery).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(GetMessagesQuery).Name}, Invalid model.");
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.mediator.Send(new SendMessageCommand(model));
                    this.logger.LogInformation($"command: {typeof(SendMessageCommand).Name}");
                    return this.Ok(result);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"command: {typeof(SendMessageCommand).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(SendMessageCommand).Name}, Invalid model.");
                return this.BadRequest();
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(MessagesDetailsModel))]
        public async Task<IActionResult> EditMessage(EditMessageModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.mediator.Send(new EditMessageCommand(model));
                    this.logger.LogInformation($"command: {typeof(EditMessageCommand).Name}");
                    return this.Ok(result);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"command: {typeof(EditMessageCommand).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(EditMessageCommand).Name}, Invalid model.");
                return this.BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            if (MessageChecks.MessageIdValid(this.context, id))
            {
                try
                {
                    var result = await this.mediator.Send(new DeleteMessageCommand(id));
                    this.logger.LogInformation($"command: {typeof(DeleteMessageCommand).Name}");
                    return this.Ok(result);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"command: {typeof(DeleteMessageCommand).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(DeleteMessageCommand).Name}, Invalid model.");
                return this.BadRequest();
            }
        }
    }
}
