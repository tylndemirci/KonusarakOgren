using System.ComponentModel.DataAnnotations;

namespace KonusarakOgren.DTO.Auth
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords does not match!")]
        public string ConfirmPassword { get; set; }
    }
}