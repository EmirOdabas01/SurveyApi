using SurveyApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class QuestionType
    {
        public Guid Id { get; set; }
        public required QuestType Type { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
