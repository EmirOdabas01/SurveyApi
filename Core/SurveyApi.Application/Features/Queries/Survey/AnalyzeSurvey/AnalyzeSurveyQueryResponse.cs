using SurveyApi.Application.DTOs.SurveyAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.AnalyzeSurvey
{
    public class AnalyzeSurveyQueryResponse
    {
        public  QuestionAnalysisDto QuestionAnalysis { get; set; }
        public StatisticAnalysisDto StatisticAnalysis { get; set; }
    }
}
