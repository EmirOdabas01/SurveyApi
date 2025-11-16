using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.SurveyAnalysis
{
    public class FullSurveyAnalysisDto
    {
        public StatisticAnalysisDto StatisticAnalysis { get; set; }
        public QuestionAnalysisDto QuestionAnalysis { get; set; }
    }
}
