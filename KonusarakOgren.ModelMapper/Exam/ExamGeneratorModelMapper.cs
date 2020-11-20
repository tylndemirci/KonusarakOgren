using KonusarakOgren.Model.Exam;
using KonusarakOgren.Model.Exam.Response;

namespace KonusarakOgren.ModelMapper.Exam
{
    public static class ExamGeneratorModelMapper
    {
        public static ExamGeneratorViewModel MapToModel(this ScrapeWiredComResponseModel model)
        {
            if (model == null) return null;
            return new ExamGeneratorViewModel() {TitleList = model.TitleList, ContentList = model.ContentList};
        }
        
       
    }
}