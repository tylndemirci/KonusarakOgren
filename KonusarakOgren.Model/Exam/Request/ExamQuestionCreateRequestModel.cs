﻿namespace KonusarakOgren.Model.Exam.Request
{
    public class ExamQuestionCreateRequestModel
    {
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string Answer { get; set; }
        public int ExamId { get; set; }
    }
}    