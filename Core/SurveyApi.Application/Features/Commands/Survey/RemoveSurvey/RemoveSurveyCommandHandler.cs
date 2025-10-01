using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Repositories;
using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Survey.RemoveSurvey
{
    internal class RemoveSurveyCommandHandler : IRequestHandler<RemoveSurveyCommandRequest, RemoveSurveyCommandResponse>
    {
        private readonly ISurveyWriteRepository _surveyWriteRepository;
        private readonly IAnswerWriteRepository _answerWriteRepository;
        private readonly ISurveyReadRepository _surveyReadRepository;

        public RemoveSurveyCommandHandler(ISurveyWriteRepository surveyWriteRepository, 
            IAnswerWriteRepository answerWriteRepository,
            ISurveyReadRepository surveyReadRepository)
        {
            _surveyWriteRepository = surveyWriteRepository;
            _answerWriteRepository = answerWriteRepository;
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<RemoveSurveyCommandResponse> Handle(RemoveSurveyCommandRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository.GetWhere(s => s.SurveyId == Guid.Parse(request.Id))
                .Include(s => s.SurveyStatus)
                .Include(s => s.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync();
               
            
            if(survey == null)
                throw new Exception();
            
            if (survey.SurveyStatus.SurveyStatuse != Status.Planned.ToString())
            {
                var questions = survey.Questions.ToList();

                foreach(var question in questions)
                {
                    var answerList = question.Answers.ToList();
                    _answerWriteRepository.RemoveRange(answerList);
                }

                await _answerWriteRepository.SaveAsync();
            }

            await _surveyWriteRepository.RemoveAsync(request.Id);
            await _surveyWriteRepository.SaveAsync();

          return new();
        }
    }
}
