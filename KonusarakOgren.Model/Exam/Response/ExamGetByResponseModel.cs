using System.Collections.Generic;
using KonusarakOgren.Entity.Entities;

namespace KonusarakOgren.Model.Exam.Response
{
    public class ExamGetByResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<ExamQuestionResponseModel> ExamQuestions { get; set; }
    }
}