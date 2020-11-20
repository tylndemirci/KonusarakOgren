using System;
using System.Collections.Generic;
using KonusarakOgren.Entity.Entities;

namespace KonusarakOgren.Model.Models
{
    public class ListExamsViewModel
    {
        public ListExamsViewModel(Exam exam)
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