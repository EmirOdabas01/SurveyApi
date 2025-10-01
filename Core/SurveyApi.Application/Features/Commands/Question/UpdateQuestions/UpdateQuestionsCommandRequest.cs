using MediatR;
using SurveyApi.Application.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Question.UpdateQuestions
{
    public class UpdateQuestionsCommandRequest : IRequest<UpdateQuestionsCommandResponse>
    {
        public string SurveyId { get; set; }
        public List<VM_Update_Question> Questions { get; set; }
    }
}
