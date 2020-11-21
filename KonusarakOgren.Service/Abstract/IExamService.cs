using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using KonusarakOgren.Core;
using KonusarakOgren.DTO.Exam;
using KonusarakOgren.DTO.Exam.Response;
using KonusarakOgren.Entity.Entities;
using KonusarakOgren.Model.Exam.Response;

namespace KonusarakOgren.Service.Abstract
{
    public interface IExamService
    {    
        ServiceResult CreateExam(ExamCreateRequestDto createRequestDto);
        ServiceResult DeleteExam(int examId);
        ServiceResult<List<ExamGetResponseDto>> GetAll();
        ServiceResult<ExamGetExamResponseDto> GetExam(int examId);
    }    
}