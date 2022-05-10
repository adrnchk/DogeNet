// <copyright file="AccountController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.IdentityServer.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using DogeNet.BLL.Features.Account.CreateAccount;
    using DogeNet.DAL.Models;
    using DogeNet.IdentityServer.ViewModels;
    using IdentityServer4.Services;
    using IdentityServer4.Stores;
    using MediatR;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IIdentityServerInteractionService interaction;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IMediator mediator, IMapper mapper, IIdentityServerInteractionService interaction)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mediator = mediator;
            this.mapper = mapper;
            this.interaction = interaction;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await this.userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("UserName", "User not Found");
                return View(model);
            }

            var signinResult = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (signinResult.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            this.ModelState.AddModelError("UserName", "Something went wrong");
            return this.View(model);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var viewModel = new RegisterViewModel
            {
                ReturnUrl = returnUrl,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = new IdentityUser
            {
                UserName = model.UserName,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var userModel = this.mapper.Map<RegisterViewModel, CreateAccountModel>(model);
                userModel.IdentityId = user.Id;

                await this.mediator.Send(new CreateAccountCommand(userModel));

                await this.signInManager.SignInAsync(user, false);
                return this.Redirect(model.ReturnUrl);
            }

            this.ModelState.AddModelError(string.Empty, "Error occured");
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await this.signInManager.SignOutAsync();
            var logoutResult = await this.interaction.GetLogoutContextAsync(logoutId);
            return this.Redirect(logoutResult.PostLogoutRedirectUri);
        }
    }
}
