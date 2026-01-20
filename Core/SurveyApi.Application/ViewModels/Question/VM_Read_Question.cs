using SurveyApi.Application.Enums;
using SurveyApi.Application.ViewModels.QuestionOption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.ViewModels.Question
{
    public class VM_Read_Question
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int Type { get; set; }
        public string QuestionText { get; set; }
        public bool IsMandatory { get; set; }

        public List<VM_Read_QuestionOption>? QuestionOptions { get; set; }
    }
}
