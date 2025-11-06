using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Survey.CloseSurvey
{
    public class CloseSurveyCommandRequest : IRequest<CloseSurveyCommandResponse>
    {
        public string SurveyId { get; set; }
    }
}
