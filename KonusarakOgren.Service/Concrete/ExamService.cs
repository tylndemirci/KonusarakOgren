using KonusarakOgren.Core;
using KonusarakOgren.DTO.Exam;
using KonusarakOgren.DtoMapper.Exam;
using KonusarakOgren.Entity.Abstract;
using KonusarakOgren.Entity.Entities;
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
    }
}