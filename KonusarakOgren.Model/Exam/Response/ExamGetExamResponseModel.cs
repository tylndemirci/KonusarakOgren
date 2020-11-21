using System.Collections.Generic;

namespace KonusarakOgren.Model.Exam.Response
{
    public class ExamGetExamResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<ExamQuestionResponseModel> ExamQuestions { get; set; }
        public string DateTime { get; set; }
    }
}