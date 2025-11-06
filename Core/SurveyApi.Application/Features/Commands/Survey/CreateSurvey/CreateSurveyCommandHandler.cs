using MediatR;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.Services;
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
            var response = await _surveyService.CreateSurveyAsync(request);
            return response;
        }
    }
}
