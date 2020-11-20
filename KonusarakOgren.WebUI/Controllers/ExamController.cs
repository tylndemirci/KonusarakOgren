using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Entity.Abstract;
using KonusarakOgren.Entity.Entities;
using KonusarakOgren.Model.Exam.Request;
using KonusarakOgren.ModelMapper.Exam;
using KonusarakOgren.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebUI.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamBusiness _examBusiness;
        private readonly IGenericDal<Exam> _examDal;

        public ExamController(IGenericDal<Exam> examDal, IExamBusiness examBusiness)
        {
            _examDal = examDal;
            _examBusiness = examBusiness;
        }


        public IActionResult ExamGenerator()
        {
            var articles = _examBusiness.ScrapeWiredCom().GetAwaiter().GetResult();
            
            return View(articles.MapToModel());
        }
        
        public IActionResult ListExams()
        {
            var exams = _examDal.GetAll()
                .Where(x => x.IsDeleted == false)
                .Select(x=> new ListExamsViewModel(x));
            return View(exams);
        }

        [HttpGet]
        public IActionResult CreateExam(ExamCreateRequestModel model)
        {
           var result = _examBusiness.CreateExam(model);
            return View(result);
        }

        [HttpPost]
        public IActionResult CreateExam(CreateExamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var returnExam = new Exam();
                returnExam.Title = model.Title;
                returnExam.Content = model.Content;
                returnExam.ExamQuestions = model.ExamQuestions;
                returnExam.DateTime = DateTime.Now.ToString("yyyy-MM-dd");
                _examBusiness.CreateExam(TODO);
                return RedirectToAction("ListExams", "Exam");
            }


            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteExam(int examId)
        {
            _examBusiness.DeleteExam(examId);
            
            return RedirectToAction("ListExams", "Exam");
        }


      
    }
}