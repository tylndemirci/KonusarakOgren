using System;
using KonusarakOgren.Model.Auth;

namespace KonusarakOgren.Business.Concrete
{
    public partial class AuthBusiness
    {
        private void LoginValidation(LoginViewModel model)
        {
            if (model == null) throw new Exception("User not found.");
            if (model.Username== null) throw new Exception("Username is required.");
            if (model.Password ==null) throw new Exception("Password is required.");
        }

        private void RegisterValidation(RegisterViewModel model)
        {
            if (model.Username== null) throw new Exception("Username is required.");
            if (model.Password ==null) throw new Exception("Password is required.");
            if (model.ConfirmPassword== null) throw new Exception("ConfirmPassword is required.");
          
        }
       
    }
}