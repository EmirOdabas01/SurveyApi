using MediatR;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.SurveyImage.UploadSurveyImage
{
    public class UploadSurveyImageCommandHandler : IRequestHandler<UploadSurveyImageCommandRequest, UploadSurveyImageCommandResponse>
    {

        private readonly ISurveyService _surveyService;

        public UploadSurveyImageCommandHandler(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task<UploadSurveyImageCommandResponse> Handle(UploadSurveyImageCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _surveyService.UploadSurveyImageAsync(request);
            return response;
        }
    }
}
