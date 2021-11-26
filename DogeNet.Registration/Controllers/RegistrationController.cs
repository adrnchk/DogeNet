﻿// <copyright file="RegistrationController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.Registration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public async Task<IActionResult> Register(CreateAccountCommand command)
        {
            // Validation here...
            var validator = new CreateAccountValidator();
            var validationResults = validator.Validate(command.model);

            if (validationResults.IsValid)
            {
                return this.Ok(await this.mediator.Send(command));
            }
            else
            {
                return this.NotFound(validationResults.Errors);
            }
        }
    }
}
