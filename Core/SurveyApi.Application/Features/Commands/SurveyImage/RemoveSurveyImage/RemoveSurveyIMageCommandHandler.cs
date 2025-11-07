using MediatR;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.SurveyImage.RemoveSurveyImage
{
    public class RemoveSurveyIMageCommandHandler : IRequestHandler<RemoveSurveyIMageCommandRequest, RemoveSurveyIMageCommandResponse>
    {

        private readonly ISurveyService _surveyService;

        public RemoveSurveyIMageCommandHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<RemoveSurveyIMageCommandResponse> Handle(RemoveSurveyIMageCommandRequest request, CancellationToken cancellationToken)
        {
            await _surveyService.RemoveSurveyImageAsync(request.Id);
            return new();
        }
    }
}
