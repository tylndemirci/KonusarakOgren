using System.Threading.Tasks;
using KonusarakOgren.Model.Auth;
using KonusarakOgren.Model.Auth.Response;

namespace KonusarakOgren.Business.Abstract
{
    public interface IAuthBusiness
    {
        Task<AuthResponseModel> UserRegister(RegisterViewModel model);
        Task<AuthResponseModel> UserLogin(LoginViewModel model);
        Task<AuthResponseModel> Logout();
    }
}