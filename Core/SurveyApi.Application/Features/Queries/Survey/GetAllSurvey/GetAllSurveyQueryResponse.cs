using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetAllSurvey
{
    public class GetAllSurveyQueryResponse 
    {
       public int Count { get; set; }
       public Object Surveys { get; set; }
    }
}
