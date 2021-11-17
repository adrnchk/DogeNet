// <copyright file="UserController.cs" company="Leobit">
// Copyright (c) Leobit. All rights reserved.
// </copyright>

namespace DogeNet.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public string GetSecretTest()
        {
            return "Secret info";
        }
    }
}
