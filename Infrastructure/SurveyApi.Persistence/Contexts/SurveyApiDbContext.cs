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
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<SurveyStatus>()
                .HasData(
                new { Id = Convert.ToInt32(Status.Planned), SurveyStatuse = Status.Planned.ToString() },
                new { Id = Convert.ToInt32(Status.Open), SurveyStatuse = Status.Open.ToString() },
                new { Id = Convert.ToInt32(Status.Closed), SurveyStatuse = Status.Closed.ToString()}
                );

            modelBuilder.Entity<QuestionType>()
                .HasData(
                new { Id = Convert.ToInt32(QuestType.Open), Type = QuestType.Open.ToString() },
                new { Id = Convert.ToInt32(QuestType.Dropdown), Type = QuestType.Dropdown.ToString() },
                new { Id = Convert.ToInt32(QuestType.MultipleChoice), Type = QuestType.MultipleChoice.ToString()},
                new { Id = Convert.ToInt32(QuestType.Logical), Type = QuestType.Logical.ToString() }
                );

            modelBuilder.Entity<Visibility>()
                .HasData(
                new {Id = Convert.ToInt32(VisibilityStat.Public), State = VisibilityStat.Public.ToString()},
                new {Id = Convert.ToInt32(VisibilityStat.Group), State = VisibilityStat.Group.ToString()},
                new {Id = Convert.ToInt32(VisibilityStat.Private), State = VisibilityStat.Private.ToString()}
                );
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<Survey>();

            foreach(var data in datas)
            {
                if(data.State == EntityState.Added)
                {
                    data.Entity.SurveyStatusId = Convert.ToInt32(Status.Planned);
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        
    }
}