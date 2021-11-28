using DogeNet.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeNet.BLL.Services.Implementations
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<IdentityUser> userManager;

        public UserManagerService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> CreateIdentityUser(IdentityUser user, string password)
        {
            return await this.userManager.CreateAsync(user, password);
        }
    }
}
