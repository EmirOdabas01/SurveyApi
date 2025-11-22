using SurveyApi.Application.DTOs.SurveyAnalysis.QuestionAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Abstractions.Services.SurveyAnalysis
{
    public interface ISurveyOpenQuestionAnalysis
    {
        Task<List<OpenQuestionAnalysisDto>> AnalyzeSurvey(string SurveyIds);
    }
}
