using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurvey
{
    public class GetAllSurveyQueryHandler : IRequestHandler<GetAllSurveyQueryRequest, GetAllSurveyQueryResponse>
    {
        private readonly ISurveyReadRepository _surveyReadRepository;

        public GetAllSurveyQueryHandler(ISurveyReadRepository surveyReadRepository)
        {
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<GetAllSurveyQueryResponse> Handle(GetAllSurveyQueryRequest request, CancellationToken cancellationToken)
        {
            var surveys =  _surveyReadRepository.GetAll(false)
                .Where(s => s.Visibility.State == "All" && s.SurveyStatus.SurveyStatuse == "Planned")
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
