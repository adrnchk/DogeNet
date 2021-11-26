using DogeNet.BLL.Features.Account.CreateAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogeNet.Registration.Controllers
{
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
                return Ok(await mediator.Send(command));
            }
            else
            {
                return NotFound(validationResults.Errors);
            }

        } 
    }
}
