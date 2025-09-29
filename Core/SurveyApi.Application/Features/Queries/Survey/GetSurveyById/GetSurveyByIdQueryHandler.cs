using MediatR;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetSurveyById
{
    public class GetSurveyByIdQueryHandler : IRequestHandler<GetSurveyByIdQueryRequest, GetSurveyByIdQueryResponse>
    {
        private readonly ISurveyReadRepository _surveyReadRepository;

        public GetSurveyByIdQueryHandler(ISurveyReadRepository surveyReadRepository)
        {
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<GetSurveyByIdQueryResponse> Handle(GetSurveyByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(request.Id, false);

            if(survey == null)
                throw new Exception();

            return new()
            {
                Id = survey.Id,
                Name = survey.Name,
                Description = survey.Description,
            };
        }
    }
}
