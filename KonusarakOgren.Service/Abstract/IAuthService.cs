using System.Threading.Tasks;
using KonusarakOgren.Core;
using KonusarakOgren.DTO.Auth;

namespace KonusarakOgren.Service.Abstract
{
    public interface IAuthService
    {
        Task<ServiceResult> Login(LoginRequestDto dto);
        Task<ServiceResult>Register(RegisterRequestDto dto);
        Task<ServiceResult> Logout();
    }
}