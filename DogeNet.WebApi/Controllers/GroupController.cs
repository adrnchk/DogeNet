// <copyright file="GroupController.cs" company="Leobit">
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
        private readonly ILogger<GroupController> logger;

        private readonly DBContext context;

        public GroupController(IMediator mediator, DBContext context, ILogger<GroupController> logger)
        {
            this.mediator = mediator;
            this.context = context;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GroupDetailsModel))]
        public async Task<IActionResult> GetGroupById(int id)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var group = await this.mediator.Send(new GetGroupQuery(id));
                    this.logger.LogInformation($"command: {typeof(GetGroupQuery).Name}");
                    return this.Ok(group);
                }
                catch (Exception e)
                {
                    this.logger.LogError(e, $"command: {typeof(GetGroupQuery).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(GetGroupQuery).Name}, Invalid model");
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.mediator.Send(new CreateGroupCommand(model));
                    this.logger.LogInformation($"command: {typeof(CreateGroupCommand).Name}, Group created");

                    return this.Ok();
                }
                catch (Exception e)
                {
                    this.logger.LogError(e, $"command: {typeof(CreateGroupCommand).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(CreateGroupCommand).Name}, Invalid model");
                return this.BadRequest(this.ModelState.Values);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(GroupDetailsModel))]
        public async Task<IActionResult> EditGroup(EditGroupModel model)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.mediator.Send(new EditGroupCommand(model));
                    this.logger.LogInformation($"command: {typeof(EditGroupCommand).Name}");
                    return this.Ok(result);
                }
                catch (Exception e)
                {
                    this.logger.LogError(e, $"command: {typeof(EditGroupCommand).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(EditGroupCommand).Name}, Invalid model");
                return this.BadRequest(this.ModelState.Values);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.mediator.Send(new DeleteGroupCommand(id));
                    this.logger.LogInformation($"command: {typeof(DeleteGroupCommand).Name}");
                    return this.Ok(result);
                }
                catch (Exception e)
                {
                    this.logger.LogError(e, $"command: {typeof(DeleteGroupCommand).Name}");
                    return this.BadRequest();
                }
            }
            else
            {
                this.logger.LogError($"command: {typeof(DeleteGroupCommand).Name}, Invalid model");
                return this.BadRequest();
            }
        }
    }
}
