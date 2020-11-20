using System.Collections.Generic;
using System.Linq;
using KonusarakOgren.Core;
using KonusarakOgren.DTO.Exam;
using KonusarakOgren.DTO.Exam.Response;
using KonusarakOgren.Model.Exam;
using KonusarakOgren.Model.Exam.Request;
using KonusarakOgren.Model.Exam.Response;

namespace KonusarakOgren.ModelMapper.Exam
{
    public static class ExamMapperToModel
    {
        public static ExamGetResponseModel MapToModel(this ExamGetResponseDto dto)
        {
            if (dto == null) return null;
            return new ExamGetResponseModel()
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content,
                DateTime = dto.DateTime
            };
        }

        public static ExamQuestionResponseModel MapToModel(this ExamQuestionResponseDto model)
        {
            if (model == null) return null;
            return new ExamQuestionResponseModel()
            {
                Question = model.Question,
                OptionA = model.OptionA,
                OptionB = model.OptionB,
                OptionC = model.OptionC,
                OptionD = model.OptionD,
                Answer = model.Answer,
                ExamId = model.ExamId
            };
        }

        public static ExamGetAllResponseModel MapToModel(
            this ServiceResult<List<ExamGetResponseDto>> result)
        {
            if (result == null) return null;
            if (!result.Success) return new ExamGetAllResponseModel() {Success = false, Message = "Kayıt bulunamadı."};
            return new ExamGetAllResponseModel()
                {Success = true, Exams = result.Data.Select(x => x.MapToModel()).ToList()};
        }
        
        public static ExamCreateRequestModel MapToModel(this CreateExamViewModel model)
        {
            if (model == null) return null;
            return new ExamCreateRequestModel()
            {
                Title = model.Title,
                Content = model.Content,
            };
        }
        

    }
}