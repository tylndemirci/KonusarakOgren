using System.Linq;
using KonusarakOgren.DTO.Exam;
using KonusarakOgren.DTO.Exam.Response;
using KonusarakOgren.Entity.Entities;
using KonusarakOgren.Model.Exam.Response;
using KonusarakOgren.ModelMapper.Exam;

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
                ExamQuestions = model.ExamQuestions.Select(x => x.MapToEntity()).ToList(),
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

        public static  ExamGetExamResponseDto MapToDto(this Entity.Entities.Exam exam)
        {
            if (exam == null) return null;
            return new ExamGetExamResponseDto()
            {
                Id = exam.Id,
                Title = exam.Title,
                Content = exam.Content,
                DateTime = exam.DateTime,
                ExamQuestions = exam.ExamQuestions.Select(x=>x.MapToDto()).ToList()
            };
        }
        
        public static  ExamGetResponseDto MapToDtoGetAll(this Entity.Entities.Exam exam)
        {
            if (exam == null) return null;
            return new ExamGetResponseDto()
            {
                Id = exam.Id,
                Title = exam.Title,
                Content = exam.Content,
                DateTime = exam.DateTime,
            };
        }
      
        public static ExamCreateResponseDto CreateMapToDto(this Entity.Entities.Exam exam)
        {
            if (exam == null) return null;
            return new ExamCreateResponseDto()
            {
                Title = exam.Title,
                Content = exam.Content,
                ExamQuestions = exam.ExamQuestions.Select(x => x.MapToDto()).ToList(),
                DateTime = exam.DateTime
            };
        }
        
        public static Entity.Entities.Exam  MapToDto(this ExamCreateResponseDto dto)
        {
            if (dto == null) return null;
            return new Entity.Entities.Exam()
            {
                Title = dto.Title,
                Content = dto.Content,
                ExamQuestions = dto.ExamQuestions.Select(x => x.MapToDto()).ToList(),
                DateTime = dto.DateTime
            };
        }
       
        
        public static ExamQuestion MapToDto(this ExamQuestionResponseDto dto)
        {
            if (dto == null) return null;
            return new ExamQuestion
            {
                Question = dto.Question,
                OptionA = dto.OptionA,
                OptionB = dto.OptionB,
                OptionC = dto.OptionC,
                OptionD = dto.OptionD,
                Answer = dto.Answer,
            };
        }
        

        public static ExamQuestionResponseDto MapToDto(this ExamQuestion exam)
        {
            if (exam == null) return null;
            return new ExamQuestionResponseDto
            {
                Id = exam.Id,
                ExamId = exam.ExamId,
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