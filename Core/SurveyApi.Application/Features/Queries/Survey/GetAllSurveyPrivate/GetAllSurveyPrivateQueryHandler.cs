using MediatR;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurveyPrivateQuery;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurveyPrivate
{
    public class GetAllSurveyPrivateQueryHandler : IRequestHandler<GetAllSurveyPrivateQueryRequest, GetAllSurveyPrivateQueryResponse>
    {
        private readonly ISurveyReadRepository _surveyReadRepository;

        public GetAllSurveyPrivateQueryHandler(ISurveyReadRepository surveyReadRepository)
        {
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<GetAllSurveyPrivateQueryResponse> Handle(GetAllSurveyPrivateQueryRequest request, CancellationToken cancellationToken)
        {
            var surveys = _surveyReadRepository.GetAll(false)
               .Where(s => s.Visibility.State == VisibilityStat.Private.ToString() && s.SurveyStatus.SurveyStatuse == Status.Open.ToString())
               .Skip(request.Size * request.Page)
               .Take(request.Size)
               .Select(s => new {
                   Id = s.SurveyId,
                   Name = s.Name,
                   Description = s.Description,
               }).ToList(); 

            int count = surveys.Count();
            return new()
            {
                Count = count,
                Surveys = surveys
            };
        }
    }
}
