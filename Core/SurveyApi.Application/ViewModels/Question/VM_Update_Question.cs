using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.ViewModels.Question
{
    public class VM_Update_Question
    {
        public string Id { get; set; }
        public int Order { get; set; }
        public string QuestionText { get; set; }
        public bool IsMandatory { get; set; }
    }
}
