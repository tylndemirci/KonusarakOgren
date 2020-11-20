using System.Collections.Generic;
using KonusarakOgren.Entity.Entities;

namespace KonusarakOgren.Model.Models
{
    public class CreateExamViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<ExamQuestion> ExamQuestions { get; set; }
        public string Answer { get; set; }
    }
}