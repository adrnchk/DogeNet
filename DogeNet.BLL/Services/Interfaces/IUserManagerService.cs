using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeNet.BLL.Services.Interfaces
{
    public interface IUserManagerService
    {
        Task<IdentityResult> CreateIdentityUser(IdentityUser user, string password);
    }
}
