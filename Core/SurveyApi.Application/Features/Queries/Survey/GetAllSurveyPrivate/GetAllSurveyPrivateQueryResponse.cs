using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurveyPrivateQuery
{
    public class GetAllSurveyPrivateQueryResponse
    {
        public int Count { get; set; }
        public object Surveys { get; set; }
    }
}
