using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurveyForUsers
{
    public class GetAllSurveyForUsersQueryResponse
    {
        public int Count { get; set; }
        public object Surveys { get; set; }
    }
}
