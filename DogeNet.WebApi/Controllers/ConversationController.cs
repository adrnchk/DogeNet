// <copyright file="ConversationController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Conversations.CreateConversation;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IMediator mediator;

        public ConversationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public string GetConversations(int id)
        {
            return "value";
        }

        [HttpPost]
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
