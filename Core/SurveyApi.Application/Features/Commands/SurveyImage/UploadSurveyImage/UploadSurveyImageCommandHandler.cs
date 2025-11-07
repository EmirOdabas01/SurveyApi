using MediatR;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Repositories;
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
            await _surveyService.UploadSurveyImageAsync(new DTOs.SurveyImage.UploadSurveyImageDto
            {
                Id = request.Id,
                Files = request.Files
            });
            return new();
        }
    }
}
