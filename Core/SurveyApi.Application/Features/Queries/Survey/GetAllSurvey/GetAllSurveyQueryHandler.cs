using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurvey
{
    public class GetAllSurveyQueryHandler : IRequestHandler<GetAllSurveyQueryRequest, GetAllSurveyQueryResponse>
    {
        private readonly ISurveyService _surveyService;

        public GetAllSurveyQueryHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<GetAllSurveyQueryResponse> Handle(GetAllSurveyQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyService.GetAllSurveyAsync(new DTOs.Survey.GetAllSurveyRequestDto
            {
                Page = request.Page,
                Size = request.Size
            });
            return new GetAllSurveyQueryResponse
            {
                Count = response.Count,
                Surveys = response.Surveys
            };
        }
    }
}
