using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Abstractions.Services.SurveyAnalysis;
using SurveyApi.Application.DTOs.SurveyAnalysis;
using SurveyApi.Application.DTOs.SurveyAnalysis.QuestionAnalysis;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Exceptions;
using SurveyApi.Application.Repositories;
using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Infrastructure.Services.SurveyAnalysis
{
    public class SurveyQuestionAnalysisService : ISurveyQuestionAnalysisService
    {
        private readonly ISurveyReadRepository _surveyReadRepository;

        public SurveyQuestionAnalysisService(ISurveyReadRepository surveyReadRepository)
        {
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<QuestionAnalysisDto> AnalyzeSurvey(string SurveyId)
        {
            var survey = await _surveyReadRepository
                .GetWhere(s => s.SurveyId == Guid.Parse(SurveyId))
                .Include(s => s.Questions)
                .ThenInclude(q => q.QuestionOptions)
                .Include(s => s.Questions)
                .ThenInclude(q => q.Answers)
                .ThenInclude(a => a.AnswerOptions)
                .FirstOrDefaultAsync();

            if (survey == null)
                throw new AnalysisFailException("Survey not Found");
            else if (survey.SurveyStatusId != (int)Status.Closed)
                throw new AnalysisFailException("Survey must be closed to get analyzed");

            var optionQuestions = survey.Questions.Where(q => q.QuestionTypeId != (int)QuestType.Open).ToList();

            if (optionQuestions.Any(q => q.QuestionOptions == null))
                throw new AnalysisFailException("Unfinished survey can not be analyzed");

            QuestionAnalysisDto questionAnalysis = new();

            foreach (var question in optionQuestions)
            {
                int totalAnswerCount = question.QuestionOptions.Sum(qo => qo.AnswerOptions?.Count ?? 0);

                SingleQuestionAnalysisDto singleQuestionAnalysis = new()
                {
                    QuestionText = question.QuestionText,
                    Order = question.Order
                };

                foreach (var option in question.QuestionOptions)
                {
                    int optionAnswerCount = option.AnswerOptions?.Count ?? 0;

                    double ratio = totalAnswerCount > 0
                        ? (double)optionAnswerCount * 100 / totalAnswerCount
                        : 0;

                    OptionAnalysisInfoDto optionAnalysisInfo = new()
                    {
                        OptionText = option.Value,
                        Order = option.Order,
                        Ratio = ratio
                    };
                    singleQuestionAnalysis.OptionAnalysisInfo.Add(optionAnalysisInfo);
                }
                questionAnalysis.SingleQuestionAnalysis.Add(singleQuestionAnalysis);
            }

            int optionQuestionsCount = optionQuestions.Count;
            int unsolvedCount = optionQuestions.Count(q => q.Answers == null || q.Answers.Count == 0);

            questionAnalysis.UnsolvedRatio = optionQuestionsCount > 0
                ? (double)unsolvedCount * 100 / optionQuestionsCount
                : 0;

            return questionAnalysis;
        }
    }
}