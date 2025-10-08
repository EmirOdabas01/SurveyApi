using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Question.RemoveSingleQuestion
{
    public class RemoveSingleQuestionCommandRequest : IRequest<RemoveSingleQuestionCommandResponse>
    {
        public int Id { get; set; }
        public string SurveyId { get; set; }
    }
}
