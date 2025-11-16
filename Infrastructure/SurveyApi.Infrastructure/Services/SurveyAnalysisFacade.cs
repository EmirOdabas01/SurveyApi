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
            var statisticAnalysisTask = _surveyStatisticsService.AnalyzeSurvey(surveyId);
            var questionAnalysisTask = _surveyQuestionAnalysisService.AnalyzeSurvey(surveyId);

            await Task.WhenAll(statisticAnalysisTask, questionAnalysisTask);

            return new FullSurveyAnalysisDto
            {
                StatisticAnalysis = statisticAnalysisTask.Result,
                QuestionAnalysis = questionAnalysisTask.Result
            };
        }
    }
}
