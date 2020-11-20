using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KonusarakOgren.Entity.Entities;
using KonusarakOgren.Model.Exam.Response;

namespace KonusarakOgren.Business.Abstract
{
    public interface IExamBusiness
    {
        public void CreateExam(Exam exam);
        public void DeleteExam(int examId);
        
        
        public Task<ScrapeWiredComResponseModel> ScrapeWiredCom();
    }
}