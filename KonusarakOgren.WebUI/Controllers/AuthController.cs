using System;
using System.Collections.Generic;
using System.Linq;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KonusarakOgren.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthBusiness _authBusiness;

        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
           _authBusiness.UserLogin(model.Username, model.Password);
           
            return RedirectToAction();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}