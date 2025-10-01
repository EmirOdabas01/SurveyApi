using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Question : BaseEntity
    {
        public int Order { get; set; }
        public string QuestionText { get; set; }
        public bool IsMandatory { get; set; }
        public Survey Survey { get; set; }
        public QuestionType QuestionType { get; set; }
        public ICollection<QuestionOption> QuestionOptions { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public Guid SurveyId { get; set; }
        public int QuestionTypeId { get; set; }
    }
}
