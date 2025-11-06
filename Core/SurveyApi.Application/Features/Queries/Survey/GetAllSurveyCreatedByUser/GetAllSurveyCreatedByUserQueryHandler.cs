using MediatR;
using SurveyApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurveyCreatedByUser
{
    public class GetAllSurveyCreatedByUserQueryHandler : IRequestHandler<GetAllSurveyCreatedByUserQueryRequest, GetAllSurveyCreatedByUserQueryResponse>
    {
        private readonly ISurveyService _surveyService;

        public GetAllSurveyCreatedByUserQueryHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<GetAllSurveyCreatedByUserQueryResponse> Handle(GetAllSurveyCreatedByUserQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyService.GetUserSurveysAsync(request);
            return response;
        }
    }
}
