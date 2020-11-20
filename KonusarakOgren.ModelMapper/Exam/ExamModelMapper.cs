﻿using System.Linq;
using KonusarakOgren.DTO.Exam;
using KonusarakOgren.Model.Exam.Request;

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
                ExamQuestions = model.ExamQuestions.Select(x=>x.MapToDto()).ToList(),
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

    }
}