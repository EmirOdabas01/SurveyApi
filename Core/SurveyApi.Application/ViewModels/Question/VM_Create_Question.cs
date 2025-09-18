using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.ViewModels.Question
{
    public class VM_Create_Question
    {
        public int Order { get; set; }
        public string QuestionText { get; set; }
        public bool IsMandatory { get; set; }
        public string SurveyId { get; set; }
        public string QuestionTypeId { get; set; }
    }
}
