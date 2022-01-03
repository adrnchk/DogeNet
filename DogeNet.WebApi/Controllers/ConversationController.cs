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

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly DBContext context;

        public ConversationController(IMediator mediator, DBContext context)
        {
            this.mediator = mediator;
            this.context = context;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(List<ConversationDetailsModel>))]
        public async Task<IActionResult> GetConversations(int id)
        {
            if (AccountChecks.UserIdValid(this.context, id))
            {
                return this.Ok(await this.mediator.Send(new GetConversationsQuery(id)));
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ConversationDetailsModel))]
        public async Task<IActionResult> GetConversationById(int id)
        {
            if (ConversationChecks.ConversationIdValid(this.context, id))
            {
                return this.Ok(await this.mediator.Send(new GetConversationByIdQuery(id)));
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ConversationDetailsModel))]
        public async Task<IActionResult> CreateConversation(CreateConversationModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new CreateConversationCommand(model)));
            }
            else
            {
                return this.BadRequest(this.ModelState.Values);
            }
        }
    }
}
