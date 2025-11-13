using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Exceptions
{
    public class SurveyNotAccessibleException : Exception
    {
        public SurveyNotAccessibleException()
        {
        }

        public SurveyNotAccessibleException(string? message) : base(message)
        {
        }

        public SurveyNotAccessibleException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
