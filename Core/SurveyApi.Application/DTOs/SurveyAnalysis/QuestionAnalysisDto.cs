using SurveyApi.Application.DTOs.SurveyAnalysis.QuestionAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.SurveyAnalysis
{
    public class QuestionAnalysisDto
    {
        public List<SingleQuestionAnalysisDto> SingleQuestionAnalysis { get; set; } = new();
        public Double UnsolvedRatio { get; set; }
    }
}
