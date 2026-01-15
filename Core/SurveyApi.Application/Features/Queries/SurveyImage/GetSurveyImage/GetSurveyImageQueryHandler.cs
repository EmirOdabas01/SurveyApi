using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.SurveyImage.GetSurveyImage
{
    public class GetSurveyImageQueryHandler : IRequestHandler<GetSurveyImageQueryRequest, GetSurveyImageQueryResponse>
    {

        private readonly ISurveyService _surveyService;

        public GetSurveyImageQueryHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<GetSurveyImageQueryResponse> Handle(GetSurveyImageQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyService.GetSurveyImageAsync(request.SurveyId);
            return new GetSurveyImageQueryResponse
            {
                Id = response.Id,
                Path = response.Path
            };
        }
    }
}
