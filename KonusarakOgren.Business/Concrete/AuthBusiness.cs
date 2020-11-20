using System;
using KonusarakOgren.Business.Abstract;
using Microsoft.AspNetCore.Identity;

namespace KonusarakOgren.Business.Concrete
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AuthBusiness(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async void UserRegister(string username, string password)
        {
            var usernameCheck = await _userManager.FindByNameAsync(username);
            if (usernameCheck != null) throw new ArgumentException("Username already exists.");


            var user = new IdentityUser();
            user.UserName = username;

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded) throw new ArgumentException("Something went wrong.");
        }

        public async void UserLogin(string username, string password)
        {
            var userCheck = await _userManager.FindByNameAsync(username);
            if (userCheck == null) throw new ArgumentException("User not found.");

            await _signInManager.SignOutAsync();
            var result = await _signInManager.PasswordSignInAsync(userCheck, password, false, false);
            if (!result.Succeeded) throw new ArgumentException("Something went wrong.");
        }

        public async void Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}