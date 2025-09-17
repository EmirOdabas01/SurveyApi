using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.ViewModels.Answer
{
    public class VM_Create_Answer
    {
        public string? QuestionAnswer { get; set; }
        public string QuestionId { get; set; }
        public string ResponseId { get; set; }
    }
}
