using MediatR;
using SurveyApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Survey.CloseSurvey
{
    public class CloseSurveyCommandHandler : IRequestHandler<CloseSurveyCommandRequest, CloseSurveyCommandResponse>
    {
        private readonly ISurveyService _surveyService;

        public CloseSurveyCommandHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<CloseSurveyCommandResponse> Handle(CloseSurveyCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyService.CloseSurveyAsync(request);
            return response;
        }
    }
}
