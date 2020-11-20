using System.Collections.Generic;

namespace KonusarakOgren.Entity.Entities
{
    public class ExamQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }

        public string Answer { get; set; }
        
        public virtual Exam Exam { get; set; }
        public int ExamId { get; set; }
    }
}