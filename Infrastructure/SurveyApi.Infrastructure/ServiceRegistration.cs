using Microsoft.Extensions.DependencyInjection;
using SurveyApi.Application.Abstractions;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Abstractions.Services.SurveyAnalysis;
using SurveyApi.Infrastructure.Services;
using SurveyApi.Infrastructure.Services.SurveyAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<ISurveyStatisticsService, SurveyStatisticsService>();
            services.AddScoped<ISurveyQuestionAnalysisService, SurveyQuestionAnalysisService>();
            services.AddScoped<ISurveyAnalysisFacade, SurveyAnalysisFacade>();
        }
    }
}
