using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogeNet.WebApi.Controllers
{
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
