// <copyright file="GroupController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Controllers
{
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Group.CreateGroup;
    using DogeNet.BLL.Features.Group.DeleteGroup;
    using DogeNet.BLL.Features.Group.EditGroup;
    using DogeNet.BLL.Features.Group.GetGroup;
    using DogeNet.DAL;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly DBContext context;

        public GroupController(IMediator mediator, DBContext context)
        {
            this.mediator = mediator;
            this.context = context;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(GroupDetailsModel))]
        public async Task<IActionResult> GetGroupById(int id)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new GetGroupQuery(id)));
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new CreateGroupCommand(model)));
            }
            else
            {
                return this.BadRequest(this.ModelState.Values);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(GroupDetailsModel))]
        public async Task<IActionResult> EditGroup(EditGroupModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new EditGroupCommand(model)));
            }
            else
            {
                return this.BadRequest(this.ModelState.Values);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new DeleteGroupCommand(id)));
            }
            else
            {
                return this.BadRequest();
            }
        }

    }
}
