using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;
using KonusarakOgren.Core;
using KonusarakOgren.DTO.Exam;
using KonusarakOgren.DTO.Exam.Response;
using KonusarakOgren.DtoMapper.Exam;
using KonusarakOgren.Entity.Abstract;
using KonusarakOgren.Entity.Entities;
using KonusarakOgren.Model.Exam.Response;
using KonusarakOgren.ModelMapper.Exam;
using KonusarakOgren.Service.Abstract;

namespace KonusarakOgren.Service.Concrete
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ServiceResult CreateExam(ExamCreateRequestDto createRequestDto)
        {
            _unitOfWork.GetRepository<Exam>().Create(createRequestDto.MapToEntity());

            return new ServiceResult() {Success = _unitOfWork.SaveChanges() > 0};
        }

        public ServiceResult DeleteExam(int examId)
        {
            var exam = _unitOfWork.GetRepository<Exam>().GetBy(x => x.Id == examId).FirstOrDefault();
            if (exam != null) exam.IsDeleted = true;
            return new ServiceResult() {Success = _unitOfWork.SaveChanges() > 0};
        }

        public ServiceResult<List<ExamGetResponseDto>> GetAll()
        {
            var exams = _unitOfWork.GetRepository<Exam>().GetAll().Where(x => x.IsDeleted == false).ToList();
            return new ServiceResult<List<ExamGetResponseDto>>() {Data = exams.Select(x=> x.MapToDto()).ToList(), Success = true};
        }

        public ServiceResult<List<ExamGetResponseDto>> GetBy(Expression<Func<Exam, bool>> predicate)
        {
            var exams = _unitOfWork.GetRepository<Exam>().GetBy(predicate);
            return new ServiceResult<List<ExamGetResponseDto>>(){Data = exams.Select(x=>x.MapToDto()).ToList(), Success = true};
        }
    }
}