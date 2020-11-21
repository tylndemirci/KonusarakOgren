using System.Threading.Tasks;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Model.Auth;
using KonusarakOgren.Model.Auth.Response;
using KonusarakOgren.ModelMapper.Auth;
using KonusarakOgren.Service.Abstract;

namespace KonusarakOgren.Business.Concrete
{
    public partial class AuthBusiness : IAuthBusiness
    {
        private readonly IAuthService _authService;

        public AuthBusiness(IAuthService authService)
        {
            _authService = authService;
        }


        public async Task<AuthResponseModel> UserRegister(RegisterViewModel model)
        {
           await _authService.Register(model.MaptoDto());
           return new AuthResponseModel(){Success = true};
        }

        public async Task<AuthResponseModel> UserLogin(LoginViewModel model)
        {
            await _authService.Login(model.MapToDto());
            return new AuthResponseModel() {Success = true};
        }

        public async Task<AuthResponseModel> Logout()
        {
           await _authService.Logout();
            return new AuthResponseModel() {Success = true};
        }
    }
}