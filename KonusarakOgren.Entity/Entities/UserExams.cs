using System;
using Microsoft.AspNetCore.Identity;

namespace KonusarakOgren.Entity.Entities
{
    public class UserExams
    {
        public int Id { get; set; }
        public virtual IdentityUser User{ get; set; }
        public virtual Exam Exam { get; set; }
    }
}