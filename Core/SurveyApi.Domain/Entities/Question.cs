using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Question : BaseEntity
    {
        public required int Order { get; set; }
        public required string QuestionText { get; set; }
        public required bool IsMandatory { get; set; }
        public Survey Survey { get; set; }
        public QuestionType QuestionType { get; set; }
        public ICollection<QuestionOption> QuestionOptions { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
