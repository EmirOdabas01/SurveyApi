using MediatR;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurveyForGroups
{
    public class GetAllSurveyForGroupsQueryHandler : IRequestHandler<GetAllSurveyForGroupsQueryRequest, GetAllSurveyForGroupsQueryResponse>
    {
        private readonly ISurveyService _surveyService;

        public GetAllSurveyForGroupsQueryHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<GetAllSurveyForGroupsQueryResponse> Handle(GetAllSurveyForGroupsQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyService.GetAllSurveyForGroupAsync();
            return new GetAllSurveyForGroupsQueryResponse
            {
                Count = response.Count,
                GroupSurveys = response.Surveys
            };
        }
    }
}
