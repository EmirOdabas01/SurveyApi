using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SurveyApi.Application.Enums;
using SurveyApi.Domain.Entities;
using SurveyApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SurveyApi.Persistence.Contexts
{
    public class SurveyApiDbContext : IdentityDbContext<User, Role, string>
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

            modelBuilder.Entity<Survey>()
                .HasKey(s => s.SurveyId);

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

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Users)
                .WithMany(u => u.Groups);

            //modelBuilder.Entity<ImageFile>()
            //    .HasKey(ı => ı.Id);

            modelBuilder.Entity<ImageFile>()
                .HasOne(ı => ı.Survey)
                .WithOne(s => s.ImageFile)
                .HasForeignKey<ImageFile>(ı => ı.SurveyId);

            modelBuilder.Entity<Visibility>()
                .HasMany(v => v.Surveys)
                .WithOne(s => s.Visibility)
                .HasForeignKey(s => s.VisibilityId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Responses)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SurveyStatus>()
                .HasData(
                new { Id = (int)Status.Planned, SurveyStatuse = nameof(Status.Planned)},
                new { Id = (int)Status.Open, SurveyStatuse = nameof(Status.Open) },
                new { Id = (int)Status.Closed, SurveyStatuse = nameof(Status.Closed)}
                );

            modelBuilder.Entity<QuestionType>()
                .HasData(
                new { Id = (int)QuestType.Open, Type = nameof(QuestType.Open) },
                new { Id = (int)QuestType.Dropdown, Type = nameof(QuestType.Dropdown) },
                new { Id =  (int) QuestType.MultipleChoice, Type = nameof(QuestType.MultipleChoice)},
                new { Id = (int) QuestType.Logical, Type = nameof(QuestType.Logical) }
                );

            modelBuilder.Entity<Visibility>()
                .HasData(
                new {Id = (int)VisibilityStat.Public, State = nameof(VisibilityStat.Public)},
                new {Id = (int)VisibilityStat.Group, State = nameof(VisibilityStat.Group)},
                new {Id = (int)VisibilityStat.Private, State = nameof(VisibilityStat.Private)}
                );

            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<Survey>();

            foreach(var data in datas)
            {
                if(data.State == EntityState.Added)
                {
                    data.Entity.SurveyStatusId = (int)Status.Planned;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        
    }
}