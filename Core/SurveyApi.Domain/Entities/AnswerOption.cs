using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class AnswerOption : BaseEntity
    {
        public QuestionOption QuestionOption { get; set; }
        public Answer Answer { get; set; }

        public int QuestionOptionId { get; set; }
        public int AnswerId { get; set; }
    }
}
