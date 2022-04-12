// <copyright file="ConversationController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Account;
    using DogeNet.BLL.Features.Conversations;
    using DogeNet.BLL.Features.Conversations.CreateConversation;
    using DogeNet.BLL.Features.Conversations.GetConversationById;
    using DogeNet.BLL.Features.Conversations.GetConversations;
    using DogeNet.DAL;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly ILogger<ConversationController> logger;

        private readonly DBContext context;

        public ConversationController(IMediator mediator, DBContext context, ILogger<ConversationController> logger)
        {
            this.mediator = mediator;
            this.context = context;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(List<ConversationDetailsModel>))]
        public async Task<IActionResult> GetConversations(int id)
        {
            if (AccountChecks.UserIdValid(this.context, id))
            {
                try
                {
                    var result = await this.mediator.Send(new GetConversationsQuery(id));
                    this.logger.LogInformation($"command: {typeof(GetConversationsQuery).Name}");
                    return this.Ok(result);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"command: {typeof(GetConversationsQuery).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(GetConversationsQuery).Name}, Invalid model.");
                return this.BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ConversationDetailsModel))]
        public async Task<IActionResult> GetConversationById(int id)
        {
            if (ConversationChecks.ConversationIdValid(this.context, id))
            {
                try
                {
                    var result = await this.mediator.Send(new GetConversationByIdQuery(id));
                    this.logger.LogInformation($"command: {typeof(GetConversationByIdQuery).Name}");
                    return this.Ok(result);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"command: {typeof(GetConversationByIdQuery).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(GetConversationByIdQuery).Name}, Invalid model.");
                return this.BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ConversationDetailsModel))]
        public async Task<IActionResult> CreateConversation(CreateConversationModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.mediator.Send(new CreateConversationCommand(model));
                    this.logger.LogInformation($"command: {typeof(CreateConversationCommand).Name}");
                    return this.Ok(result);
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, $"command: {typeof(CreateConversationCommand).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(CreateConversationCommand).Name}, Invalid model.");

                return this.BadRequest(this.ModelState.Values);
            }
        }
    }
}
