using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class QuestionOption
    {
        public Guid QuestionOptionId { get; set; }
        public required int Order { get; set; }
        public required string Value { get; set; }
    }
}
