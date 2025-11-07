using MediatR;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Survey.CreateSurvey
{
    public class CreateSurveyCommandHandler : IRequestHandler<CreateSurveyCommandRequest, CreateSurveyCommandResponse>
    {
        private readonly ISurveyService _surveyService;

        public CreateSurveyCommandHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<CreateSurveyCommandResponse> Handle(CreateSurveyCommandRequest request, CancellationToken cancellationToken)
        {
           await _surveyService.CreateSurveyAsync(new DTOs.Survey.CreateSurveyDto
            {
                Name = request.Name,
                Description = request.Description,
                Visibility = request.Visibility,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                MinResponse = request.MinResponse,
                MaxResponse = request.MaxResponse
            });
            return new();
        }
    }
}
