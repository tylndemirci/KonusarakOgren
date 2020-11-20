using System;
using System.Collections.Generic;
using KonusarakOgren.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace KonusarakOgren.Entity
{
    public class KonusarakOgrenContext : IdentityDbContext<IdentityUser>
    {
        public KonusarakOgrenContext(DbContextOptions<KonusarakOgrenContext> options) : base(options)
        { }
        

        public DbSet<Exam> Sorular { get; set; }
        public DbSet<ExamQuestion> SoruCevaplari { get; set; }

    }
}