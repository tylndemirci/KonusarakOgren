using System.Linq;
using KonusarakOgren.DTO.Exam;
using KonusarakOgren.DTO.Exam.Response;
using KonusarakOgren.Entity.Entities;
using KonusarakOgren.Model.Exam.Request;
using KonusarakOgren.Model.Exam.Response;

namespace KonusarakOgren.ModelMapper.Exam
{
    public static class ExamModelMapper
    {
        public static ExamCreateRequestDto MapToDto(this ExamCreateRequestModel model)
        {
            if (model == null) return null;
            return new ExamCreateRequestDto
            {
                Title = model.Title,
                Content = model.Content,
                ExamQuestions = model.ExamQuestions.Select(x => x.MapToDto()).ToList(),
                DateTime = model.DateTime
            };
        }

        public static ExamQuestionCreateRequestDto MapToDto(this ExamQuestionCreateRequestModel model)
        {
            if (model == null) return null;
            return new ExamQuestionCreateRequestDto
            {
                Question = model.Question,
                OptionA = model.OptionA,
                OptionB = model.OptionB,
                OptionC = model.OptionC,
                OptionD = model.OptionD,
                Answer = model.Answer,
            };
        }


        public static ExamGetResponseDto MapToDto(this Entity.Entities.Exam exam)
        {
            if (exam == null) return null;
            return new ExamGetResponseDto()
            {
                Title = exam.Title,
                Content = exam.Content,
                ExamQuestions = exam.ExamQuestions.Select(x => x.MapToDto()).ToList(),
                DateTime = exam.DateTime
            };
        }

        

        public static ExamQuestionResponseDto MapToDto(this ExamQuestion exam)
        {
            if (exam == null) return null;
            return new ExamQuestionResponseDto
            {
                Question = exam.Question,
                OptionA = exam.OptionA,
                OptionB = exam.OptionB,
                OptionC = exam.OptionC,
                OptionD = exam.OptionD,
                Answer = exam.Answer,
            };
        }
    }
}