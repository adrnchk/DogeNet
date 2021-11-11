using System.ComponentModel.DataAnnotations;

namespace DogeNet.IdentityServer.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ReturnUrl { get; set; } = "https://localhost:7001/swagger/index.html";
    }
}