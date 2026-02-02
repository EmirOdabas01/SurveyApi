using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Repositories;

namespace BackgroundJobs
{
    public class SurveyStateBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(1);

        public SurveyStateBackgroundService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                await UpdateSurveyStatesAsync(stoppingToken);
                await Task.Delay(_interval, stoppingToken);
            }
        }

        private async Task UpdateSurveyStatesAsync(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();

            var surveyReadRepository = scope.ServiceProvider
                .GetRequiredService<ISurveyReadRepository>();
            var surveyWriteRepository = scope.ServiceProvider
                .GetRequiredService<ISurveyWriteRepository>();

            var currentTime = DateTime.UtcNow;

            var surveys = surveyReadRepository.GetAll()
                .Where(s =>
                    (s.SurveyStatusId != (int)Status.Open &&
                     s.StartDate <= currentTime &&
                     s.EndDate > currentTime)
                    ||
                    (s.SurveyStatusId != (int)Status.Closed &&
                     s.EndDate <= currentTime))
                .ToList();

            if (!surveys.Any())
            {
                return;
            }

            foreach (var survey in surveys)
            {
                if (stoppingToken.IsCancellationRequested)
                    break;

                if (survey.EndDate <= currentTime)
                {
                    survey.SurveyStatusId = (int)Status.Closed;
                }
                else if (survey.StartDate <= currentTime && survey.EndDate > currentTime)
                {
                    survey.SurveyStatusId = (int)Status.Open;
                }
            }

            await surveyWriteRepository.SaveAsync();
        }
    }
}