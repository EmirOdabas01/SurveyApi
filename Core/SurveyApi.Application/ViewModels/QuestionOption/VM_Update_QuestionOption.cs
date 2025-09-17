using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.ViewModels.QuestionOption
{
    public class VM_Update_QuestionOption
    {
        public string Id { get; set; }
        public int Order { get; set; }
        public string Value { get; set; }
    }
}
