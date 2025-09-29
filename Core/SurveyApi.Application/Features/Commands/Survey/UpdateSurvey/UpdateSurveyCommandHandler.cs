using MediatR;
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
        private readonly ISurveyWriteRepository _surveyWriteRepository;
        private readonly ISurveyReadRepository _surveyReadRepository;

        public UpdateSurveyCommandHandler(ISurveyWriteRepository surveyWriteRepository,
            ISurveyReadRepository surveyReadRepository)
        {
            _surveyWriteRepository = surveyWriteRepository;
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<UpdateSurveyCommandResponse> Handle(UpdateSurveyCommandRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(request.Id);

            if (survey.SurveyStatus.SurveyStatuse != "Planed")
                throw new Exception();

            survey.Name = request.Name;
            survey.Description = request.Description;
            survey.MinResponse = request.MinResponse;
            survey.MaxResponse = request.MaxResponse;
            survey.StartDate = request.StartDate;
            survey.EndDate = request.EndDate;
            survey.Visibility = request.Visibility.ToString();

            await _surveyWriteRepository.SaveAsync();
            return new();
        }
    }
}
