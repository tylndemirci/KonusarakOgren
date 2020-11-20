using System.ComponentModel.DataAnnotations;

namespace KonusarakOgren.Model.Auth
{
    public class LoginViewModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}