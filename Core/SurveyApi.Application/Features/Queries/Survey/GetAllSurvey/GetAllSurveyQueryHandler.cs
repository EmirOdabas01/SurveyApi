using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.RequestParameters;
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
            var query = _surveyReadRepository.GetAll(false).Skip(request.Size * request.Page).Take(request.Size);

            if (request.Visibility == Visibility.All)
            {
                query = query.Where(s => s.Visibility == request.Visibility.ToString());
            }
            if (request.Visibility == Visibility.Users)
            {
                query = query.Where(s => s.Visibility == request.Visibility.ToString());
            }
            if (request.Visibility == Visibility.Group)
            {
                query = query.Where(s => s.Visibility == request.Visibility.ToString());
            }

            int count = query.Count();
            var surveys = query.Select(s => new 
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                EndDate = s.EndDate
            }).ToList();

            return new()
            { 
                Count = count, 
                Surveys = surveys 
            };
        }
    }
}
