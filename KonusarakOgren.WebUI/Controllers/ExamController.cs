using System;
using System.Linq;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Entity.Abstract;
using KonusarakOgren.Entity.Entities;
using KonusarakOgren.Model.Exam;
using KonusarakOgren.Model.Exam.Request;
using KonusarakOgren.Model.Exam.Response;
using KonusarakOgren.ModelMapper.Exam;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebUI.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamBusiness _examBusiness;

        public ExamController(IExamBusiness examBusiness)
        {
            _examBusiness = examBusiness;
        }


        public IActionResult ExamGenerator()
        {
            var articles = _examBusiness.ScrapeWiredCom()
                .GetAwaiter()
                .GetResult();
            
            return View(articles);
        }
        
        public IActionResult ListExams()
        {
            var exams = _examBusiness.GetAllExams();
            return View(exams);
        }

        [HttpGet]
        public IActionResult CreateExam(CreateExamViewModel model)
        {
            var returnModel = model.MapToModel();
            return View(returnModel);
        }

        [HttpPost]
        public IActionResult CreateExam(ExamCreateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                _examBusiness.CreateExam(model);
                return RedirectToAction("ListExams", "Exam");
            }


            return View(model);
        }

       
        public IActionResult TakeExam(int examId)
        {
            var exam = _examBusiness.GetExam(examId);
            return View(exam);
        }

      
        public IActionResult DeleteExam(int examId)
        {
            _examBusiness.DeleteExam(examId);
            
            return RedirectToAction("ListExams", "Exam");
        }


      
    }
}