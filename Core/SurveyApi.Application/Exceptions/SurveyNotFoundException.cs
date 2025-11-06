using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Exceptions
{
    public class SurveyNotFoundException : Exception
    {
        public SurveyNotFoundException() : base("Survey Not Found")
        {
        }

        public SurveyNotFoundException(string? message) : base(message)
        {
        }

        public SurveyNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
