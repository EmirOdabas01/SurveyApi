using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Response
{
    public class StartSurveyCommandRequest : IRequest<StartSurveyCommandResponse>
    {
        public string SurveyId { get; set; }
    }
}
