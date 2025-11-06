using MediatR;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetSurveyByIdDetail
{
    public class GetSurveyByIdDetailQueryHandler : IRequestHandler<GetSurveyByIdDetailQueryRequest, GetSurveyByIdDetailQueryResponse>
    {
        private readonly ISurveyService _surveyService;

        public GetSurveyByIdDetailQueryHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<GetSurveyByIdDetailQueryResponse> Handle(GetSurveyByIdDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyService.GetSurveyByIdDetailAsync(request);
            return response;
        }
    }
}
