using SurveyApi.Application.DTOs.SurveyAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Abstractions.Services.SurveyAnalysis
{
    public interface ISurveyStatisticsService
    {
        Task<StatisticAnalysisDto> AnalyzeSurvey(string SurveyId);
    }
}
