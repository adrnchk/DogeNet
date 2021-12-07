// <copyright file="RegistrationController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Registration.Controllers
{
    using System.Threading.Tasks;
    using DogeNet.BLL.Features.Account.CreateAccount;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IMediator mediator;

        public RegistrationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateAccountModel model)
        {
            var command = new CreateAccountCommand(model);

            if (this.ModelState.IsValid)
            {
                return this.Ok(await this.mediator.Send(command));
            }
            else
            {
                return this.BadRequest(this.ModelState.Values);
            }
        }
    }
}
