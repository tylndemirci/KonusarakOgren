namespace KonusarakOgren.ModelMapper.Exam
{
    public class ExamModelMapper
    {
        public static ExamGeneratorViewModel MapToModel(this ScrapeWiredComResponseModel model)
        {
            if (model == null) return null;
            return new ExamGeneratorViewModel() {TitleList = model.TitleList, ContentList = model.ContentList};
        }

    }
}