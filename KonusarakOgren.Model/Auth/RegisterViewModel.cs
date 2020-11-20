using System.ComponentModel.DataAnnotations;

namespace KonusarakOgren.Model.Models
{
    public class RegisterViewModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords does not match!")]
        public string ConfirmPassword { get; set; }
    }
}