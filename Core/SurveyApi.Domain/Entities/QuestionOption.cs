using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class QuestionOption : BaseEntity
    {
        public int Order { get; set; }
        public string Value { get; set; }
        public Question Question { get; set; }
        public ICollection<AnswerOption> AnswerOptions { get; set; }

        public Guid QuestionId { get; set; }
    }
}
