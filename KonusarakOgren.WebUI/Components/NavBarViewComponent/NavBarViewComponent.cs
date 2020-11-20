using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebUI.Components.NavBarViewComponent
{
    public class NavBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}