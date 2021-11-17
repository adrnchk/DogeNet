// <copyright file="AccountController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.IdentityServer.Controllers
{
    using System.Threading.Tasks;
    using DogeNet.DAL.Models;
    using DogeNet.IdentityServer.ViewModels;
    using IdentityServer4.Services;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IIdentityServerInteractionService interaction;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, IIdentityServerInteractionService interaction)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.interaction = interaction;
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

            var user = new User
            {
                UserName = model.UserName,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, false);
                return this.Redirect(model.ReturnUrl);
            }

            this.ModelState.AddModelError(string.Empty, "Error occured");
            return this.View(model);
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
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                this.ModelState.AddModelError("UserName", "User not found");
                return this.View(model);
            }

            var signinResult = await this.signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (signinResult.Succeeded)
            {
                return this.Redirect(model.ReturnUrl);
            }

            this.ModelState.AddModelError("UserName", "Something went wrong");
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await this.signInManager.SignOutAsync();
            var logoutRequest = await this.interaction.GetLogoutContextAsync(logoutId);
            return this.Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}
