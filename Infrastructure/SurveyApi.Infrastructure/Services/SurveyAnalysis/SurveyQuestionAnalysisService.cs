using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Abstractions.Services.SurveyAnalysis;
using SurveyApi.Application.DTOs.SurveyAnalysis;
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

           

            List<(string, int, string)> mostSelectedOptions = new();
            List<(string, int, string)> leastSelectedOptions = new();
            List<((string, int), List<(string, double)>)> questionOptionsSelectionRatio = new();

            var notOpenQuestions = survey.Questions.Where(q => q.QuestionTypeId != (int)QuestType.Open)
               .Select(q => q).ToList();

            foreach (var data in notOpenQuestions)
            {
                Dictionary<int, int> optionAnswersCount = new();
                foreach(var answer in data.Answers)
                {
                    
                    foreach(var answerOption in answer.AnswerOptions)
                    {
                        if(!optionAnswersCount.ContainsKey(answerOption.QuestionOptionId))
                        {
                            optionAnswersCount.Add(answerOption.QuestionOptionId, 1);
                        }
                        else
                        {
                            optionAnswersCount[answerOption.QuestionOptionId]++;
                        }
                    }
                }

                List<(string, double)> optionsSelectionRatio = new();
                foreach (var pair in optionAnswersCount)
                {
                   double ratio = (int)pair.Value * 100 / optionAnswersCount.Values.Sum();
                   string optionName = data.QuestionOptions.FirstOrDefault(qo => qo.Id == pair.Key).Value;
                    optionsSelectionRatio.Add((optionName, ratio));  
                }

                questionOptionsSelectionRatio.Add(((data.QuestionText, data.Order), optionsSelectionRatio));

                int max = optionAnswersCount.Values.Max();
                int min = optionAnswersCount.Values.Min();

                int maxId = optionAnswersCount.First(k => k.Value == max).Key;
                int minId = optionAnswersCount.First(k => k.Value == min).Key;

                // Logical 
                if(maxId == minId)
                {
                    minId = optionAnswersCount.Last(k => k.Value == min).Key;
                }

                var minSelected = data.QuestionOptions.First(qo => qo.Id == minId);
                var maxSelected = data.QuestionOptions.First(qo => qo.Id == maxId);

                mostSelectedOptions.Add((data.QuestionText, maxSelected.Order, maxSelected.Value));
                leastSelectedOptions.Add((data.QuestionText, minSelected.Order, minSelected.Value));
            }

            int unSolvedQuestionsCount = notOpenQuestions.Count(q => q.Answers == null);
            Double unSolvedRatio = (double)unSolvedQuestionsCount * 100 / notOpenQuestions.Count;

            return new QuestionAnalysisDto
            {
                QuestionOptionsSelectionRatio = questionOptionsSelectionRatio,
                LeastSelectedOption = leastSelectedOptions,
                MostSelectedOption = mostSelectedOptions,
                UnSolvedQuestionRatio = unSolvedRatio
            };

        }
    }
}
