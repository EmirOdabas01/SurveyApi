using MediatR;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Survey.PublishSurvey
{
    public class PublishSurveyCommandHandler : IRequestHandler<PublishSurveyCommandRequest, PublishSurveyCommandResponse>
    {
        private readonly ISurveyService _surveyService;

        public PublishSurveyCommandHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<PublishSurveyCommandResponse> Handle(PublishSurveyCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyService.PublishSurveyAsync(request.SurveyId);
            return new PublishSurveyCommandResponse
            {
                Success = response
            };
        }
    }
}
