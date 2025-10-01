using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Question.DeleteQuestions
{
    public class DeleteQuestionsCommandRequest : IRequest<DeleteQuestionsCommandResponse>
    {
        public List<string> Idies { get; set; }
    }
}
