using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.SurveyAnalysis
{
    public class QuestionAnalysisDto
    {
        public List<((string, int), List<(string, double)>)> QuestionOptionsSelectionRatio { get; set; } = new();
        public List<(string, int, string)> MostSelectedOption { get; set; } = new();
        public List<(string, int, string)> LeastSelectedOption { get; set; } = new();
        public Double UnSolvedQuestionRatio { get; set; }
    }
}
