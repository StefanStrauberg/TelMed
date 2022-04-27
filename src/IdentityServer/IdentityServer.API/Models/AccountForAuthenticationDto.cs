using System.ComponentModel.DataAnnotations;

namespace IdentityServer.API.Models
{
    public class AccountForAuthenticationDto
    {
        [Required(ErrorMessage = "Login is required.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}