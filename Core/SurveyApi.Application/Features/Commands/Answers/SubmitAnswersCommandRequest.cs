using MediatR;
using SurveyApi.Application.ViewModels.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Answers
{
    public class SubmitAnswersCommandRequest : IRequest<SubmitAnswersCommandResponse>
    {
        public int ResponseId { get; set; }
        public int QuestionId { get; set; }
        public List<VM_Submit_Answer> Answers { get; set; }
    }
}
