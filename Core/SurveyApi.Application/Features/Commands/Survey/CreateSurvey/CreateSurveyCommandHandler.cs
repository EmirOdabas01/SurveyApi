using MediatR;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Survey.CreateSurvey
{
    public class CreateSurveyCommandHandler : IRequestHandler<CreateSurveyCommandRequest, CreateSurveyCommandResponse>
    {
        private readonly ISurveyWriteRepository _surveyWriteRepository;

        public CreateSurveyCommandHandler(ISurveyWriteRepository surveyWriteRepository)
        {
            _surveyWriteRepository = surveyWriteRepository;
        }

        public async Task<CreateSurveyCommandResponse> Handle(CreateSurveyCommandRequest request, CancellationToken cancellationToken)
        {
            await _surveyWriteRepository.AddAsync(new Domain.Entities.Survey
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                MinResponse = request.MinResponse,
                MaxResponse = request.MaxResponse,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Visibility = request.Visibility.ToString(),
                SurveyStatusId = Guid.Parse(request.SurveyStatusId),
                UserId = Guid.Parse(request.UserId)
            });
            await _surveyWriteRepository.SaveAsync();
            return new();
        }
    }
}
