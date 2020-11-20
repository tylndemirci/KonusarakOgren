using System.Collections.Generic;

namespace KonusarakOgren.DTO.Exam
{
    public class ExamCreateRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<ExamQuestionCreateRequestDto> ExamQuestions { get; set; }
        public string DateTime { get; set; }
    }
}