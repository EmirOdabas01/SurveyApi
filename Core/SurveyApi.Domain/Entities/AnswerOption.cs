using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class AnswerOption
    {
        public Guid Id { get; set; }
        public QuestionOption QuestionOption { get; set; }
        public Answer Answer { get; set; }
    }
}
