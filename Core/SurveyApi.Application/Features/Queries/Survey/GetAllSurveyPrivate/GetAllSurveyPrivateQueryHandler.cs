using MediatR;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurveyPrivateQuery;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurveyPrivate
{
    public class GetAllSurveyPrivateQueryHandler : IRequestHandler<GetAllSurveyPrivateQueryRequest, GetAllSurveyPrivateQueryResponse>
    {
        private readonly ISurveyService _surveyService;

        public GetAllSurveyPrivateQueryHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<GetAllSurveyPrivateQueryResponse> Handle(GetAllSurveyPrivateQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyService.GetAllSurveyPrivateAsync(request);
            return response;
        }
    }
}
