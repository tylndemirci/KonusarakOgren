using System.Linq;
using KonusarakOgren.DTO.Exam;
using KonusarakOgren.Entity.Entities;

namespace KonusarakOgren.DtoMapper.Exam
{
    public static class ExamDtoMapper
    {

        public static Entity.Entities.Exam MapToEntity(this ExamCreateRequestDto model)
        {
            if (model == null) return null;
            return new Entity.Entities.Exam
            {
                Title = model.Title,
                Content = model.Content,
                ExamQuestions = model.ExamQuestions.Select(x=>x.MapToEntity()).ToList(),
                DateTime = model.DateTime
            };
        }
        
        public static ExamQuestion MapToEntity(this ExamQuestionCreateRequestDto model)
        {
            if (model == null) return null;
            return new ExamQuestion
            {
                Question = model.Question,
                OptionA = model.OptionA,
                OptionB = model.OptionB,
                OptionC = model.OptionC,
                OptionD = model.OptionD,
                Answer = model.Answer,
                
            };
        }
        
        
    }
}