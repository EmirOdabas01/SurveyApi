using MediatR;
using SurveyApi.Application.Enums;
using SurveyApi.Application.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurvey
{
    public class GetAllSurveyQueryRequest : IRequest<GetAllSurveyQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
        public Visibility Visibility { get; set; } = Visibility.All;
    }
}
