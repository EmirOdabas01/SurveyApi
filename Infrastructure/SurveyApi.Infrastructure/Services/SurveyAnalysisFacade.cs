using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Abstractions.Services.SurveyAnalysis;
using SurveyApi.Application.DTOs.SurveyAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Infrastructure.Services
{
    public class SurveyAnalysisFacade : ISurveyAnalysisFacade
    {
        private readonly ISurveyStatisticsService _surveyStatisticsService;
        private readonly ISurveyQuestionAnalysisService _surveyQuestionAnalysisService;

        public SurveyAnalysisFacade(ISurveyStatisticsService surveyStatisticsService,
            ISurveyQuestionAnalysisService surveyQuestionAnalysisService)
        {
            _surveyStatisticsService = surveyStatisticsService;
            _surveyQuestionAnalysisService = surveyQuestionAnalysisService;
        }

        public async Task<FullSurveyAnalysisDto> GetFullAnalysisAsync(string surveyId)
        {
            var statisticAnalysis = await _surveyStatisticsService.AnalyzeSurvey(surveyId);
            var questionAnalysis = await _surveyQuestionAnalysisService.AnalyzeSurvey(surveyId);


            return new FullSurveyAnalysisDto
            {
                StatisticAnalysis = statisticAnalysis,
                 QuestionAnalysis = questionAnalysis
            };
        }
    }
}
