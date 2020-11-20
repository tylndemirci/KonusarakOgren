using System;
using System.Collections.Generic;

namespace KonusarakOgren.Entity.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string DateTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
       
        public virtual List<ExamQuestion> ExamQuestions { get; set; }
    }
}