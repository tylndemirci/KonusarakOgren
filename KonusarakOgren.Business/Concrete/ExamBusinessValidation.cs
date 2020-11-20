using System;
using System.Linq;
using KonusarakOgren.Model.Exam.Request;

namespace KonusarakOgren.Business.Concrete
{
    public partial class ExamBusiness
    {
        private void CreateExamValidation(ExamCreateRequestModel model)
        {
            if (model==null)
            {
                throw new Exception("İstek boş olamaz.");
            }
            
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                throw new Exception("Başlık boş olamaz.");
            }
            
            if (string.IsNullOrWhiteSpace(model.Content))
            {
                throw new Exception("İçerik boş olamaz.");
            }
            
            if (model.ExamQuestions==null || model.ExamQuestions.Count==0)
            {
                throw new Exception("Sorular boş olamaz.");
            }
            
        }

        private void DeleteExamValidation(in int examId)
        {
            if (examId==0)
            {
                throw new Exception("İstek boş olamaz.");
            }
        }
    }
}