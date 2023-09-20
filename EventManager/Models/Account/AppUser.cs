using Microsoft.AspNetCore.Identity;

namespace EventManager.Models.Account
{
    public class AppUser : IdentityUser
    {
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
