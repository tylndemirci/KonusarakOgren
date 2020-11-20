using System.Collections.Generic;
using KonusarakOgren.DTO.Exam;

namespace KonusarakOgren.Model.Exam.Request
{
    public class ExamCreateRequestModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<ExamQuestionCreateRequestModel> ExamQuestions { get; set; }
        public string DateTime { get; set; }
    }
}