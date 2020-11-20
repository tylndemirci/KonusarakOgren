
using Microsoft.Build.Framework;

namespace KonusarakOgren.Model.Models
{
    public class LoginViewModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}