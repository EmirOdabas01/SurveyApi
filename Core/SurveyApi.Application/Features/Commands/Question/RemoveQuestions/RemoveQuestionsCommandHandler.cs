using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Question.DeleteQuestions
{
    public class RemoveQuestionsCommandHandler : IRequestHandler<RemoveQuestionsCommandRequest, RemoveQuestionsCommandResponse>
    {
        private readonly ISurveyWriteRepository _surveyWriteRepository;
        private readonly ISurveyReadRepository _surveyReadRepository;
        private readonly IQuestionWriteRepository _questionWriteRepository;
        public RemoveQuestionsCommandHandler(ISurveyReadRepository surveyReadRepository, 
            ISurveyWriteRepository surveyWriteRepository,
            IQuestionWriteRepository questionWriteRepository)
        {
            _surveyReadRepository = surveyReadRepository;
            _surveyWriteRepository = surveyWriteRepository;
            _questionWriteRepository = questionWriteRepository;
        }

        public async Task<RemoveQuestionsCommandResponse> Handle(RemoveQuestionsCommandRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository.Table.Include(s => s.Questions).FirstOrDefaultAsync(s => s.SurveyId == Guid.Parse(request.Id));

            if (survey == null || survey.SurveyStatusId != Convert.ToInt32(Status.Planned))
                throw new Exception();

            _questionWriteRepository.RemoveRange(survey.Questions.ToList());
            await _questionWriteRepository.SaveAsync();

            return new();
        }
    }
}
