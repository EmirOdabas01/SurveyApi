using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Abstractions.Services.SurveyAnalysis;
using SurveyApi.Application.DTOs.SurveyAnalysis.QuestionAnalysis;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Exceptions;
using SurveyApi.Application.Repositories;
using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Infrastructure.Services.SurveyAnalysis
{
    public class SurveyOpenQuestionAnalysis : ISurveyOpenQuestionAnalysis
    {
        private readonly ISurveyReadRepository _surveyReadRepository;

        public SurveyOpenQuestionAnalysis(ISurveyReadRepository surveyReadRepository)
        {
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<List<OpenQuestionAnalysisDto>> AnalyzeSurvey(string SurveyId)
        {
            var survey = await _surveyReadRepository
                .GetWhere(s => s.SurveyId == Guid.Parse(SurveyId))
                .Include(s => s.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync();

            if (survey == null)
                throw new AnalysisFailException("Survey not found");

            List<OpenQuestionAnalysisDto> answers = new();
            foreach(var question in survey.Questions)
            {
                if(question.QuestionTypeId == (int)QuestType.Open && question.Answers != null)
                {
                    answers.Add(new OpenQuestionAnalysisDto
                    {
                        Order = question.Order,
                        QuestionText = question.QuestionText,
                        Answers = question.Answers.Select(a => a.QuestionAnswer).Distinct().ToList()
                    });
                }
            }

            return answers;
        }
    }
}
