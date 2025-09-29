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
        public DbSet<Visibility> Visibilities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyStatus>()
                .HasMany(st => st.Surveys)
                .WithOne(s => s.SurveyStatus)
                .HasForeignKey(s => s.SurveyStatusId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Survey)
                .HasForeignKey(q => q.SurveyId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QuestionType>()
                 .HasMany(qt => qt.Questions)
                 .WithOne(q => q.QuestionType)
                 .HasForeignKey(q => q.QuestionTypeId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.QuestionOptions)
                .WithOne(qo => qo.Question)
                .HasForeignKey(qo => qo.QuestionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QuestionOption>()
                .HasMany(qo => qo.AnswerOptions)
                .WithOne(ao => ao.QuestionOption)
                .HasForeignKey(ao => ao.QuestionOptionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AnswerOption>()
                .HasOne(ao => ao.Answer)
                .WithMany(a => a.AnswerOptions)
                .HasForeignKey(ao => ao.AnswerId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Response>()
                .HasMany(r => r.Answers)
                .WithOne(a => a.Response)
                .HasForeignKey(a => a.ResponseId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Responses)
                .WithOne(r => r.Survey)
                .HasForeignKey(r => r.SurveyId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ImageFile>()
                .HasKey(ı => ı.Id);

            modelBuilder.Entity<ImageFile>()
                .HasOne(ı => ı.Survey)
                .WithOne(s => s.ImageFile)
                .HasForeignKey<ImageFile>(ı => ı.Id);

            modelBuilder.Entity<Visibility>()
                .HasMany(v => v.Surveys)
                .WithOne(s => s.Visibility)
                .HasForeignKey(s => s.VisibilityId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyStatus>()
                .HasData(
                new { Id = Guid.Parse("e7d9f8a2-24b1-4e73-9c6d-0e2b3f6a9a55"), SurveyStatuse = "Planned" },
                new { Id = Guid.Parse("3b8a4c1b-7f5a-45f3-8cf3-1c6f9e4b9f11"), SurveyStatuse = "Open" },
                new { Id = Guid.Parse("4c2e9d17-5f88-4a7e-a62e-2a4f0e9d3f72"), SurveyStatuse = "Closed" }
                );

            modelBuilder.Entity<QuestionType>()
                .HasData(
                new { Id = Guid.Parse("a92f1c3d-73b4-40f1-9c88-1e6d5f2c9a11"), Type = "Open" },
                new { Id = Guid.Parse("6d7f3e28-1b9c-42a1-8f4a-5c3d7e2f1b66"), Type = "Dropdown" },
                new { Id = Guid.Parse("f81c7d5a-2e4b-4a9f-97c1-6a2f3e8d9b44"), Type = "Multiple Choice" },
                new { Id = Guid.Parse("b19d5a3c-8c71-4e4f-9d0b-7f13a2e9c8d4"), Type = "Logical" }
                );

            modelBuilder.Entity<Visibility>()
                .HasData(
                new {Id = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479"), State = "All"},
                new {Id = Guid.Parse("9a1b2c3d-4e5f-6789-abcd-ef0123456789"), State = "Users"},
                new {Id = Guid.Parse("d94f3f01-2c5b-4a6a-8f1b-3b2a1c4d5e6f"), State = "Groups"}
                );
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<Survey>();

            foreach(var data in datas)
            {
                if(data.State == EntityState.Added)
                {
                    data.Entity.SurveyStatusId = Guid.Parse("e7d9f8a2-24b1-4e73-9c6d-0e2b3f6a9a55");
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        
    }
}