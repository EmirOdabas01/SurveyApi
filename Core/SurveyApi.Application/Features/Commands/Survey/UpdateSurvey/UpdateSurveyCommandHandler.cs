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

namespace SurveyApi.Application.Features.Commands.Survey.UpdateSurvey
{
    public class UpdateSurveyCommandHandler : IRequestHandler<UpdateSurveyCommandRequest, UpdateSurveyCommandResponse>
    {

        private readonly ISurveyService _surveyService;

        public UpdateSurveyCommandHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<UpdateSurveyCommandResponse> Handle(UpdateSurveyCommandRequest request, CancellationToken cancellationToken)
        {
             await _surveyService.UpdateSurveyAsync(new DTOs.Survey.UpdateSurveyDto
             {
                 Id = request.Id,
                 Name = request.Name,
                 Visibility = request.Visibility,
                 Description = request.Description,
                 StartDate = request.StartDate,
                 EndDate = request.EndDate,
                 MinResponse = request.MinResponse,
                 MaxResponse = request.MaxResponse
             });
            return new();
        }
    }
}
