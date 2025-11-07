using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurveyForGroups
{
    public class GetAllSurveyForGroupsQueryResponse
    {
        public int Count { get; set; }
        public Object GroupSurveys { get; set; }
    }
}
