using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Exceptions
{
    public class QuestionsNotFoundException : Exception
    {
        public QuestionsNotFoundException() : base("No questions found")
        {
        }

        public QuestionsNotFoundException(string? message) : base(message)
        {
        }

        public QuestionsNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
