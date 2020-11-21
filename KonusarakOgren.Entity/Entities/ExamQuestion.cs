using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KonusarakOgren.Entity.Entities
{
    public class ExamQuestion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Sorular boş olamaz.")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Seçenek boş olamaz.")]
        public string OptionA { get; set; }

        [Required(ErrorMessage = "Seçenek boş olamaz.")]
        public string OptionB { get; set; }

        [Required(ErrorMessage = "Seçenek boş olamaz.")]
        public string OptionC { get; set; }

        [Required(ErrorMessage = "Seçenek boş olamaz.")]
        public string OptionD { get; set; }

        [Required(ErrorMessage = "Cevap boş olamaz.")]
        public string Answer { get; set; }

        public virtual Exam Exam { get; set; }
        public int ExamId { get; set; }
    }
}