using System.Linq;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.ModelMapper.Exam;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebUI.Components.NavBarViewComponent
{
    public class NavBarViewComponent : ViewComponent
    {
        private readonly IExamBusiness _examBusiness;

        public NavBarViewComponent(IExamBusiness examBusiness)
        {
            _examBusiness = examBusiness;
        }

        public IViewComponentResult Invoke()
        {
            var examIds = _examBusiness.GetAllExams().Exams.Select(x => x.MapToModel()).ToList();
            return View(examIds);
        }
    }
}