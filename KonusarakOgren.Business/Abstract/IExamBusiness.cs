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
        ExamCreateResponseModel CreateExam(ExamCreateRequestModel model);
        ExamDeleteResponseModel DeleteExam(int examId);

        ExamGetAllResponseModel GetAllExams();

        ExamGetExamResponseModel GetExam(int examId);
        Task<ScrapeWiredComResponseModel> ScrapeWiredCom();
    }
}