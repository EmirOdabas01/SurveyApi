using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.SurveyAnalysis.QuestionAnalysis
{
    public class OptionAnalysisInfoDto
    {
        public string OptionText { get; set; }
        public int Order { get; set; }
        public double Ratio { get; set; }
    }
}
