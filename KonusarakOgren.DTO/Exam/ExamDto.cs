using System.Collections.Generic;

namespace KonusarakOgren.DTO.Exam
{
    public class ExamDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<ExamQuestionDto> ExamQuestions { get; set; }
        public string Answer { get; set; }
    }
}