using MediatR;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Abstractions.Services.SurveyAnalysis;
using SurveyApi.Application.DTOs.SurveyAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.AnalyzeSurvey
{
    public class AnalyzeSurveyQueryHandler : IRequestHandler<AnalyzeSurveyQueryRequest, AnalyzeSurveyQueryResponse>
    {
        private readonly ISurveyStatisticsService _surveyStatisticsService;
        private readonly ISurveyQuestionAnalysisService _surveyQuestionAnalysisService;
        private readonly ISurveyOpenQuestionAnalysis _surveyOpenQuestionAnalysis;
        public AnalyzeSurveyQueryHandler(ISurveyStatisticsService surveyStatisticsService, 
            ISurveyQuestionAnalysisService surveyQuestionAnalysisService, 
            ISurveyOpenQuestionAnalysis surveyOpenQuestionAnalysis)
        {
            _surveyStatisticsService = surveyStatisticsService;
            _surveyQuestionAnalysisService = surveyQuestionAnalysisService;
            _surveyOpenQuestionAnalysis = surveyOpenQuestionAnalysis;
        }

        public async Task<AnalyzeSurveyQueryResponse> Handle(AnalyzeSurveyQueryRequest request, CancellationToken cancellationToken)
        {
            var statisticAnalysis = await _surveyStatisticsService.AnalyzeSurvey(request.SurveyId);
            var questionAnalysis = await _surveyQuestionAnalysisService.AnalyzeSurvey(request.SurveyId);
            var openQuestionAnalysis = await _surveyOpenQuestionAnalysis.AnalyzeSurvey(request.SurveyId);

            return new AnalyzeSurveyQueryResponse
            {
                OpenQuestionAnalysis = openQuestionAnalysis,
                StatisticAnalysis = statisticAnalysis,
                QuestionAnalysis = questionAnalysis
            };
        }
    }
}
