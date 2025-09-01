using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Question
    {
        public Guid QuestionId { get; set; }
        public required int Order { get; set; }
        public required string QuestionText { get; set; }
        public required bool IsMandatory { get; set; }
    }
}
