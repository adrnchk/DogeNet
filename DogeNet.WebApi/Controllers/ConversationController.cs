// <copyright file="ConversationController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Conversations.CreateConversation;
    using DogeNet.BLL.Features.Conversations.GetConversationById;
    using DogeNet.BLL.Features.Conversations.GetConversations;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ConversationController : ControllerBase
    {
        private readonly IMediator mediator;

        public ConversationController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(List<ConversationDetailsModel>))]
        public async Task<IActionResult> GetConversations(int id) =>
            this.Ok(await this.mediator.Send(new GetConversationsQuery(id)));

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ConversationDetailsModel))]
        public async Task<IActionResult> GetConversationById(int id) =>
            this.Ok(await this.mediator.Send(new GetConversationByIdQuery(id)));

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ConversationDetailsModel))]
        public async Task<IActionResult> CreateConversation(CreateConversationModel model) =>
            this.Ok(await this.mediator.Send(new CreateConversationCommand(model)));
    }
}
