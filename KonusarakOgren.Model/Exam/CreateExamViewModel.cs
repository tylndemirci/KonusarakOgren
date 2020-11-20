using System.Collections.Generic;
using KonusarakOgren.Entity.Entities;

namespace KonusarakOgren.Model.Exam
{
    public class CreateExamViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string DateTime { get; set; }
        public List<ExamQuestionViewModel> ExamQuestions { get; set; }
        public string Answer { get; set; }
    }
}