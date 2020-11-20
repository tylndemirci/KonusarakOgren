namespace KonusarakOgren.Model.Exam
{
    public class ListExamsViewModel
    {
        public ListExamsViewModel(Entity.Entities.Exam exam)
        {
            Id = exam.Id;
            Title = exam.Title;
            DateTime = exam.DateTime;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string DateTime { get; set; }
       
        
    }
}