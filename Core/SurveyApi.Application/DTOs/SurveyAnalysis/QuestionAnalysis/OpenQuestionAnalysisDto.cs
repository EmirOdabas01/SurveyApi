using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.SurveyAnalysis.QuestionAnalysis
{
    public class OpenQuestionAnalysisDto
    {
        public string QuestionText { get; set; }
        public int Order { get; set; }
        public List<string?> Answers { get; set; }
    }
}
