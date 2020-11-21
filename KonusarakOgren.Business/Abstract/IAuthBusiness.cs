using KonusarakOgren.Model.Auth;

namespace KonusarakOgren.Business.Abstract
{
    public interface IAuthBusiness
    {
     void UserRegister(string username, string password);
       void UserLogin(LoginViewModel model);
       void Logout();
    }
}