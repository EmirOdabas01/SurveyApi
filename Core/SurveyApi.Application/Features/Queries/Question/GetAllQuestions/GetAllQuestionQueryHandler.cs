using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Features.Queries.Survey.GetSurveyByIdDetail;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.ViewModels.Question;
using SurveyApi.Application.ViewModels.QuestionOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Question.GetAllQuestions
{
    public class GetAllQuestionQueryHandler : IRequestHandler<GetAllQuestionQueryRequest, GetAllQuestionQueryResponse>
    {
        private readonly ISurveyReadRepository _surveyReadRepository;

        public GetAllQuestionQueryHandler(ISurveyReadRepository surveyReadRepository)
        {
            _surveyReadRepository = surveyReadRepository;
        }

        public async Task<GetAllQuestionQueryResponse> Handle(GetAllQuestionQueryRequest request, CancellationToken cancellationToken)
        {
            var survey = await _surveyReadRepository.GetWhere(s => s.SurveyId == Guid.Parse(request.SurveyId))
                 .Include(s => s.Questions)
                 .ThenInclude(q => q.QuestionOptions)
                 .FirstOrDefaultAsync();

            if (survey == null)
                throw new Exception("no survey");

            if (survey.Questions == null)
                return new() { SurveyId = request.SurveyId};

            List<VM_Read_Question> questions = new();

            foreach(var question in survey.Questions)
            {
                var questionOptions = question.QuestionOptions.Select(q => new VM_Read_QuestionOption
                {
                    Id = q.Id,
                    Order = q.Order,
                    Value = q.Value
                }).ToList(); 

                questions.Add(new VM_Read_Question
                {
                    Id = question.Id,
                    IsMandatory = question.IsMandatory,
                    Type = question.QuestionTypeId,
                    Order = question.Order,
                    QuestionText = question.QuestionText,
                    QuestionOptions = questionOptions
                });
            }

            return new()
            {
                SurveyId = request.SurveyId,
                Questions = questions
            };
        }
    }
}
