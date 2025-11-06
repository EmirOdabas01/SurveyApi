using MediatR;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetSurveyById
{
    public class GetSurveyByIdQueryHandler : IRequestHandler<GetSurveyByIdQueryRequest, GetSurveyByIdQueryResponse>
    {
        private readonly ISurveyService _surveyService;

        public GetSurveyByIdQueryHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<GetSurveyByIdQueryResponse> Handle(GetSurveyByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyService.GetSurveyByIdAsync(request);
            return response;
        }
    }
}
