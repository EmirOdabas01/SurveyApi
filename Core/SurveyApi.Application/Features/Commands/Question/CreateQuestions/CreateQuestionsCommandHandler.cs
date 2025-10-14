using MediatR;
using SurveyApi.Application.Repositories;
using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Question.CreateQuestions
{
    public class CreateQuestionsCommandHandler : IRequestHandler<CreateQuestionsCommandRequest, CreateQuestionsCommandResponse>
    {
        private readonly ISurveyReadRepository _surveyReadRepository;
        private readonly IQuestionWriteRepository _questionWriteRepository;

        public CreateQuestionsCommandHandler(IQuestionWriteRepository questionWriteRepository,
            ISurveyReadRepository surveyReadRepository)
        {
            _questionWriteRepository = questionWriteRepository;
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<CreateQuestionsCommandResponse> Handle(CreateQuestionsCommandRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(request.SurveyId, false);

            if (survey == null)
                throw new Exception();

            List<Domain.Entities.Question> questions = new();

            for(int i = 0; i < request.Questions.Count; i++)
            {

                var options = request.Questions[i].QuestionOptions?.Select(q => new QuestionOption
                {
                    Order = q.Order,
                    Value = q.Value
                }).ToList();

                questions.Add(new Domain.Entities.Question
                {
                    Order = request.Questions[i].Order,
                    QuestionText = request.Questions[i].QuestionText,
                    SurveyId = Guid.Parse(request.SurveyId),
                    QuestionTypeId = Convert.ToInt32(request.Questions[i].QuestionType),
                    IsMandatory = request.Questions[i].IsMandatory,
                    QuestionOptions =  options,
                });
            }

            await _questionWriteRepository.AddRangeAsync(questions);
            var result = await _questionWriteRepository.SaveAsync();

            return new();
        }
    }
}
