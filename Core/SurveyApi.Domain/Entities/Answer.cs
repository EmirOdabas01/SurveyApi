using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Answer
    {
        public Guid AnswerId { get; set; }
        public string? QuestionAnswer { get; set; }
    }
}
