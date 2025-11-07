using SurveyApi.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.Survey
{
    public class CreateSurveyDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MinResponse { get; set; }
        public int MaxResponse { get; set; }

        public VisibilityStat Visibility { get; set; }
    }
}
