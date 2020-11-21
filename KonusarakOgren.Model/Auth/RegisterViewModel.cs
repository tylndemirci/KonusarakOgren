using System.ComponentModel.DataAnnotations;

namespace KonusarakOgren.Model.Auth
{
    public class RegisterViewModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}