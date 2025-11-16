using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.AnalyzeSurvey
{
    public class AnalyzeSurveyQueryRequest : IRequest<AnalyzeSurveyQueryResponse>
    {
        public string SurveyId { get; set; }
    }
}
