// <copyright file="UserController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Controllers
{
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Account;
    using DogeNet.BLL.Features.Account.GetAccount;
    using DogeNet.BLL.Features.Account.UpdateAccount;
    using DogeNet.DAL;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AccountDetailsModel))]
        public async Task<IActionResult> GetUserById(int id) => this.Ok(await this.mediator.Send(new GetAccountQuery(id)));

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(AccountDetailsModel))]
        public async Task<IActionResult> ChangeUserInfo(UpdateAccountDetailsModel model) =>
            this.Ok(await this.mediator.Send(new UpdateAccountCommand(model)));
    }
}
