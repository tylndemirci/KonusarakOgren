using System.Collections.Generic;
using KonusarakOgren.Core;

namespace KonusarakOgren.Model.Exam.Response
{
    public class ExamGetAllResponseModel : BaseResultModel
    {
        public List<ExamGetResponseModel> Exams { get; set; }
    }
}