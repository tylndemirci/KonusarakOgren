using KonusarakOgren.Core;
using KonusarakOgren.DTO.Exam;

namespace KonusarakOgren.Service.Abstract
{
    public interface IExamService
    {
        ServiceResult CreateExam(ExamCreateRequestDto createRequestDto);
    }
}