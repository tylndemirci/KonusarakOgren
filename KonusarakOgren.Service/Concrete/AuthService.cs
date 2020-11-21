﻿using System;
using System.Threading.Tasks;
using KonusarakOgren.Core;
using KonusarakOgren.DTO.Auth;
using KonusarakOgren.Service.Abstract;
using Microsoft.AspNetCore.Identity;

namespace KonusarakOgren.Service.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthService(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ServiceResult> Login(LoginRequestDto dto)
        {
            var userCheck = await _userManager.FindByNameAsync(dto.Username);
            if (userCheck==null) throw new Exception("User not found.");
            await _signInManager.SignOutAsync();
            var result = await _signInManager.PasswordSignInAsync(userCheck, dto.Password, false, false);
            if (!result.Succeeded) throw new ArgumentException("Something went wrong.");
            return new ServiceResult(){Success = result.Succeeded};
        }

        public async Task<ServiceResult> Register(RegisterRequestDto dto)
        {
            var usernameCheck = await _userManager.FindByNameAsync(dto.Username);
            if (usernameCheck != null) throw new ArgumentException("Username already exists.");

            // var mapEntity = usernameCheck.MapToEntity();
            var identity = new IdentityUser();
            identity.UserName = dto.Username;
            
            var result = await _userManager.CreateAsync(identity, dto.Password);
            if (!result.Succeeded) throw new ArgumentException("Something went wrong.");
            return new ServiceResult(){Success = true};
        }

        public async Task<ServiceResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return new ServiceResult() {Success = true};
        }
    }
}