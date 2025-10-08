using SurveyApi.Application.ViewModels.AnswerOption;
using SurveyApi.Application.ViewModels.QuestionOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.ViewModels.Answer
{
    public class VM_Submit_Answer
    {
        public string? QuestionAnswer { get; set; }
        public string QuestionId { get; set; }
        public List<int>? QuestionOptionsIds { get; set; }
    }
}
