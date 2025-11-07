using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Repositories;
using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Survey.RemoveSurvey
{
    internal class RemoveSurveyCommandHandler : IRequestHandler<RemoveSurveyCommandRequest, RemoveSurveyCommandResponse>
    {

        private readonly ISurveyService _surveyService;

        public RemoveSurveyCommandHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<RemoveSurveyCommandResponse> Handle(RemoveSurveyCommandRequest request, CancellationToken cancellationToken)
        {
            await _surveyService.RemoveSurveyAsync(request.Id);
            return new();
        }
    }
}
