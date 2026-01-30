using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Abstractions.Services.SurveyAnalysis;
using SurveyApi.Application.DTOs.SurveyAnalysis;
using SurveyApi.Application.Exceptions;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Infrastructure.Services.SurveyAnalysis
{
    public class SurveyStatisticsService : ISurveyStatisticsService
    {
        private readonly IResponseReadRepository _responseReadRepository;

        public SurveyStatisticsService(IResponseReadRepository responseReadRepository)
        {
            _responseReadRepository = responseReadRepository;
        }

        public async Task<StatisticAnalysisDto> AnalyzeSurvey(string SurveyId)
        {
            var responses = await _responseReadRepository
                .GetWhere(r => r.SurveyId == Guid.Parse(SurveyId)).ToListAsync();

            if (responses == null || responses.Count == 0)
                throw new AnalysisFailException("There is no response yet");

            int totalResponse = responses.Count;
            int finishedCount = responses.Count(r => r.EndDate != null);
            TimeSpan totalTime = TimeSpan.Zero;

            foreach (var data in responses)
            {
                if (data.EndDate != null)
                    totalTime += data.EndDate.Value - data.BeginDate;
            }

            TimeSpan avgDuration = finishedCount > 0
                ? totalTime / finishedCount
                : TimeSpan.Zero;

            double completionRatio = totalResponse > 0
                ? (double)finishedCount * 100 / totalResponse
                : 0;

            return new StatisticAnalysisDto
            {
                TotalResponse = totalResponse,
                AvgDuration = avgDuration,
                CompletionRatio = completionRatio
            };
        }
    }
}