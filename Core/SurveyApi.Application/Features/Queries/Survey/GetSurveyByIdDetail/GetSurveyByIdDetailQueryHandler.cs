using MediatR;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Repositories;
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
            var response = await _surveyService.GetSurveyByIdDetailAsync(request.Id);
            return new GetSurveyByIdDetailQueryResponse 
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description,
                StartDate = response.StartDate,
                EndDate = response.EndDate,
                MinResponse = response.MinResponse,
                MaxResponse = response.MaxResponse
            };
        }
    }
}
