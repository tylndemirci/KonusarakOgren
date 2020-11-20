using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KonusarakOgren.Entity.Entities;
using KonusarakOgren.Model.Exam.Request;
using KonusarakOgren.Model.Exam.Response;

namespace KonusarakOgren.Business.Abstract
{
    public interface IExamBusiness
    {
        public ExamCreateResponseModel CreateExam(ExamCreateRequestModel model);
        public void DeleteExam(int examId);
        
        
        public Task<ScrapeWiredComResponseModel> ScrapeWiredCom();
    }
}