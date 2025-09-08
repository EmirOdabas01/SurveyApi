using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Persistence.Contexts
{
    public class SurveyApiDbContext : DbContext 
    {
        public SurveyApiDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyStatus> SurveyStatuses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyStatus>()
                .HasMany(st => st.Surveys)
                .WithOne(s => s.SurveyStatus)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Survey)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QuestionType>()
                 .HasMany(qt => qt.Questions)
                 .WithOne(q => q.QuestionType)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.QuestionOptions)
                .WithOne(qo => qo.Question)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QuestionOption>()
                .HasMany(qo => qo.AnswerOptions)
                .WithOne(ao => ao.QuestionOption)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AnswerOption>()
                .HasOne(ao => ao.Answer)
                .WithMany(a => a.AnswerOptions)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Response>()
                .HasMany(r => r.Answers)
                .WithOne(a => a.Response)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Responses)
                .WithOne(r => r.Survey)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Surveys)
                .WithOne(s => s.User)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Responses)
                .WithOne(r => r.User)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Users)
                .WithMany(u => u.Groups);

        }
    }
}
