using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Question.DeleteQuestions
{
    public class DeleteQuestionsCommandHandler : IRequestHandler<DeleteQuestionsCommandRequest, DeleteQuestionsCommandResponse>
    {
        public Task<DeleteQuestionsCommandResponse> Handle(DeleteQuestionsCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
