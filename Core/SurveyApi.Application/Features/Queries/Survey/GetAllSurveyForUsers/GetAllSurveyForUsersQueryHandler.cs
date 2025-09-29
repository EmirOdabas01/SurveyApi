using MediatR;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurveyForUsers
{
    public class GetAllSurveyForUsersQueryHandler : IRequestHandler<GetAllSurveyForUsersQueryRequest, GetAllSurveyForUsersQueryResponse>
    {
        private readonly ISurveyReadRepository _surveyReadRepository;

        public GetAllSurveyForUsersQueryHandler(ISurveyReadRepository surveyReadRepository)
        {
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<GetAllSurveyForUsersQueryResponse> Handle(GetAllSurveyForUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var surveys = _surveyReadRepository.GetAll(false)
               .Where(s => s.Visibility.State == "Users" && s.SurveyStatus.SurveyStatuse == "Open")
               .Skip(request.Size * request.Page)
               .Take(request.Size)
               .Select(s => new {
                   Id = s.Id,
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
