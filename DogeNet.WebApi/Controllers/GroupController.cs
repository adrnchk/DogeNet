﻿// <copyright file="GroupController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Controllers
{
    using System;
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Group.CreateGroup;
    using DogeNet.BLL.Features.Group.DeleteGroup;
    using DogeNet.BLL.Features.Group.EditGroup;
    using DogeNet.BLL.Features.Group.GetGroup;
    using DogeNet.BLL.Services.Interfaces;
    using DogeNet.DAL;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMediator mediator;

        public GroupController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GroupDetailsModel))]
        public async Task<IActionResult> GetGroupById(int id) =>
            this.Ok(await this.mediator.Send(new GetGroupQuery(id)));

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupModel model) =>
            this.Ok(await this.mediator.Send(new CreateGroupCommand(model)));

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(GroupDetailsModel))]
        public async Task<IActionResult> EditGroup(EditGroupModel model) =>
            this.Ok(await this.mediator.Send(new EditGroupCommand(model)));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id) =>
            this.Ok(await this.mediator.Send(new DeleteGroupCommand(id)));
    }
}
