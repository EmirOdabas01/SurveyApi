using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.Survey
{
    public class GetAllSurveyResponseDto
    {
        public int Count { get; set; }
        public Object Surveys { get; set; }
    }
}
