using MediatR;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetSurveyByIdDetail
{
    public class GetSurveyByIdDetailQueryHandler : IRequestHandler<GetSurveyByIdDetailQueryRequest, GetSurveyByIdDetailQueryResponse>
    {
        private readonly ISurveyReadRepository _surveyReadRepository;

        public GetSurveyByIdDetailQueryHandler(ISurveyReadRepository surveyReadRepository)
        {
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<GetSurveyByIdDetailQueryResponse> Handle(GetSurveyByIdDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(request.Id, false);

            return new()
            {
                Id = survey.SurveyId.ToString(),
                Name = survey.Name,
                Description = survey.Description,
                MinResponse = survey.MinResponse,
                MaxResponse = survey.MaxResponse,
                StartDate = survey.StartDate,
                EndDate = survey.EndDate,
            };
        }
    }
}
