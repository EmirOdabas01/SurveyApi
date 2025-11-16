using MediatR;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.AnalyzeSurvey
{
    public class AnalyzeSurveyQueryHandler : IRequestHandler<AnalyzeSurveyQueryRequest, AnalyzeSurveyQueryResponse>
    {
        private readonly ISurveyAnalysisFacade _surveyAnalysisFacade;

        public AnalyzeSurveyQueryHandler(ISurveyAnalysisFacade surveyAnalysisFacade)
        {
            _surveyAnalysisFacade = surveyAnalysisFacade;
        }

        public async Task<AnalyzeSurveyQueryResponse> Handle(AnalyzeSurveyQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyAnalysisFacade.GetFullAnalysisAsync(request.SurveyId);
            return new AnalyzeSurveyQueryResponse
            {
                FullSurveyAnalysis = response
            };
        }
    }
}
