using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Model.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            
           _authBusiness.UserLogin(model);
           
            return RedirectToAction();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}