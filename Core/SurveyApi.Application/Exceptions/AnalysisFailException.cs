using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Exceptions
{
    public class AnalysisFailException : Exception
    {
        public AnalysisFailException()
        {
        }

        public AnalysisFailException(string? message) : base(message)
        {
        }

        public AnalysisFailException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
