using System;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Model.Auth;
using KonusarakOgren.Service.Abstract;
using Microsoft.AspNetCore.Identity;

namespace KonusarakOgren.Business.Concrete
{
    public partial class AuthBusiness : IAuthBusiness
    {
        private readonly IAuthService _authService;

        public AuthBusiness(IAuthService authService)
        {
            _authService = authService;
        }


        public async void UserRegister(string username, string password)
        {
           
        }

        public async void UserLogin(LoginViewModel model)
        {
          
        }

        public async void Logout()
        {
            
        }
    }
}