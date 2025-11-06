using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.Services;
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
            var response = await _surveyService.UpdateSurveyAsync(request);
            return response;
        }
    }
}
