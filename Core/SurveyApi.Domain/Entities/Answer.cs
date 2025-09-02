using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string? QuestionAnswer { get; set; }
        public ICollection<AnswerOption> AnswerOptions { get; set; }
        public Question Question { get; set; }
        public Response Response { get; set; }

    }
}
