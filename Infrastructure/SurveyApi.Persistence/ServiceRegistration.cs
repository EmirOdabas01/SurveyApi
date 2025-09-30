using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using SurveyApi.Application.Repositories;
using SurveyApi.Persistence.Contexts;
using SurveyApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql.EntityFrameworkCore;
namespace SurveyApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
           // services.AddDbContext<SurveyApiDbContext>(options => options.UseSqlServer(Configurations.ConnectionString));
            services.AddDbContext<SurveyApiDbContext>(options => options.UseNpgsql(Configurations.ConnectionString));
            services.AddScoped<ISurveyReadRepository, SurveyReadRepository>();
            services.AddScoped<ISurveyWriteRepository, SurveyWriteRepository>();
            services.AddScoped<IResponseReadRepository, ResponseReadRepository>();
            services.AddScoped<IResponseWriteRepository, ResponseWriteRepository>();
            services.AddScoped<IQuestionOptionReadRepository, QuestionOptionReadRepository>();
            services.AddScoped<IQuestionOptionWriteRepossitory, QuestionOptionWriteRepository>();
            services.AddScoped<IQuestionReadRepository, QuestionReadRepository>();
            services.AddScoped<IQuestionWriteRepository, QuestionWriteRepository>();
            services.AddScoped<IGroupReadRepository, GroupReadRepository>();
            services.AddScoped<IGroupWriteRepository, GroupWriteRepository>();
            services.AddScoped<IAnswerOptionReadRepository, AnswerOptionReadRepository>();
            services.AddScoped<IAnswerOptionWriteRepository, AnswerOptionWriteRepository>();
            services.AddScoped<IAnswerReadRepository, AnswerReadRepository>();
            services.AddScoped<IAnswerWriteRepository, AnswerWriteRepository>();
            services.AddScoped<IImageFileReadRepository, ImageFileReadRepository>();
            services.AddScoped<IImageFileWriteRepository, ImageFileWriteRepository>();
        }
    }
}
