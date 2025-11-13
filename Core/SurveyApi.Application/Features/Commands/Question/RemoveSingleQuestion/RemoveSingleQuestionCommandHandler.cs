using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Question.RemoveSingleQuestion
{
    public class RemoveSingleQuestionCommandHandler : IRequestHandler<RemoveSingleQuestionCommandRequest, RemoveSingleQuestionCommandResponse>
    {
        private readonly ISurveyReadRepository _surveyReadRepository;
        private readonly ISurveyWriteRepository _surveyWriteRepository;
        public RemoveSingleQuestionCommandHandler(ISurveyReadRepository surveyReadRepository,ISurveyWriteRepository surveyWriteRepository)
        {
            _surveyReadRepository = surveyReadRepository;
            _surveyWriteRepository = surveyWriteRepository;
        }

        public async Task<RemoveSingleQuestionCommandResponse> Handle(RemoveSingleQuestionCommandRequest request, CancellationToken cancellationToken)
        {

            var survey = await _surveyReadRepository.Table.Include(s => s.Questions).FirstOrDefaultAsync(s => s.SurveyId == Guid.Parse(request.SurveyId));

            var questionToRemove = survey?.Questions.Where(q => q.Id == request.Id).FirstOrDefault();

            if (questionToRemove == null || survey?.SurveyStatusId != (int)Status.Planned)
                throw new Exception();

            survey.Questions.Remove(questionToRemove);
            int order = questionToRemove.Order;

            foreach(var question in survey.Questions)
            {
                if (question.Order > order)
                    --question.Order;
            }

            await _surveyWriteRepository.SaveAsync();
            return new();
        }
    }
}
