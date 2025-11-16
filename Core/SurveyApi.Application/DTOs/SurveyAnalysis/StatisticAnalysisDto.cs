using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.SurveyAnalysis
{
    public class StatisticAnalysisDto
    {
        public int TotalResponse { get; set; }
        public Double CompletionRatio { get; set; }
        public TimeSpan? AvgDuration { get; set; }
         
    }
}
