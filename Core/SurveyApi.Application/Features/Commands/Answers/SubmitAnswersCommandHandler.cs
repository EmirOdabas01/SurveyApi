using MediatR;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Repositories;
using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Answers
{
    public class SubmitAnswersCommandHandler : IRequestHandler<SubmitAnswersCommandRequest, SubmitAnswersCommandResponse>
    {
        private readonly IResponseReadRepository _responseReadRepository;
        private readonly IResponseWriteRepository _responseWriteRepository;
       
        public SubmitAnswersCommandHandler( 
            IResponseReadRepository responseReadRepository,
            IResponseWriteRepository responseWriteRepository
             )
        {
           
            _responseReadRepository = responseReadRepository;
            _responseWriteRepository = responseWriteRepository;
          
        }

        public async Task<SubmitAnswersCommandResponse> Handle(SubmitAnswersCommandRequest request, CancellationToken cancellationToken)
        {


            var response = await _responseReadRepository.GetByIdAsync(request.ResponseId);

            if (response == null)
                throw new Exception();

            List < SurveyApi.Domain.Entities.Answer > answers= new();
            foreach (var answer in request.Answers)
            {
                List<AnswerOption> answerOptions = new();

                if(answer.QuestionOptionsIds != null)
                foreach(var questionOption in answer.QuestionOptionsIds)
                {
                        answerOptions.Add(new AnswerOption
                        {
                            QuestionOptionId = questionOption
                        });
                }

                answers.Add(new SurveyApi.Domain.Entities.Answer
                {
                    QuestionAnswer = answer.QuestionAnswer,
                    QuestionId = answer.QuestionId,
                    AnswerOptions = answerOptions
                });
            }

            response.Answers = answers;
            await _responseWriteRepository.SaveAsync();

            return new();
        }
    }
}
