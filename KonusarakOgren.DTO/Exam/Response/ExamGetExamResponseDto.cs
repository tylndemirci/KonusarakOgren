using System.Collections.Generic;

namespace KonusarakOgren.DTO.Exam.Response
{
    public class ExamGetExamResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<ExamQuestionResponseDto> ExamQuestions { get; set; }
        public string DateTime { get; set; }
    }

   
}