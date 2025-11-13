using MediatR;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Question.UpdateQuestions
{
    public class UpdateQuestionsCommandHandler : IRequestHandler<UpdateQuestionsCommandRequest, UpdateQuestionsCommandResponse>
    {
        private readonly ISurveyReadRepository _surveyReadRepository;
        private readonly IQuestionWriteRepository _questionWriteRepository;
        private readonly IQuestionReadRepository _questionReadRepository;
        public UpdateQuestionsCommandHandler(ISurveyReadRepository surveyReadRepository,
            IQuestionWriteRepository questionWriteRepository,
            IQuestionReadRepository questionReadRepository)
        {
            _surveyReadRepository = surveyReadRepository;
            _questionWriteRepository = questionWriteRepository;
            _questionReadRepository = questionReadRepository;
        }
        public async Task<UpdateQuestionsCommandResponse> Handle(UpdateQuestionsCommandRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(request.SurveyId, true);

            if (survey == null || survey.SurveyStatusId != (int)Status.Planned)
                throw new Exception();
                 
            foreach (var question in request.Questions)
                {
                    var updated = await _questionReadRepository.GetByIdAsync(question.Id);
                    updated.QuestionText = question.QuestionText;
                    updated.Order = question.Order;
                    updated.IsMandatory = question.IsMandatory;
                    updated.QuestionOptions = question.QuestionOptions.Select(q => new Domain.Entities.QuestionOption
                    {
                        Id = q.Id,
                        Order = q.Order,
                        Value = q.Value
                    }).ToList();
            await _questionWriteRepository.SaveAsync();
                }

            return new();
        }
    }
}
