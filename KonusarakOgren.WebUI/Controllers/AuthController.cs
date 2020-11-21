using System.Linq;
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

       
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
          var result =  _authBusiness.UserLogin(model).GetAwaiter().GetResult();
          if (!string.IsNullOrEmpty(result.Message)) 
          {
              ViewBag.error = result.Message;
              return View(model);
          }
         
              return RedirectToAction("ListExams", "Exam");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

           var result = _authBusiness.UserRegister(model).GetAwaiter().GetResult();
            if (!string.IsNullOrEmpty(result.Message))  {
                ViewBag.error = result.Message;
                return View(model);
            }
            return RedirectToAction("ListExams", "Exam");
        }
    }
}