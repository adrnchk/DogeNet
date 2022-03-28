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
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        private readonly DBContext context;

        public UserController(IMediator mediator, DBContext context)
        {
            this.mediator = mediator;
            this.context = context;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AccountDetailsModel))]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (AccountChecks.UserIdValid(this.context, id))
            {
                return this.Ok(await this.mediator.Send(new GetAccountQuery(id)));
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(AccountDetailsModel))]
        public async Task<IActionResult> ChangeUserInfo(UpdateAccountDetailsModel model)
        {
            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(new UpdateAccountCommand(model)));
            }
            else
            {
                return this.BadRequest(this.ModelState.Values);
            }
        }
    }
}
