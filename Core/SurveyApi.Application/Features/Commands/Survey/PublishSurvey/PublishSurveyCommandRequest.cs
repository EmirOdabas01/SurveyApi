using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Survey.PublishSurvey
{
    public class PublishSurveyCommandRequest : IRequest<PublishSurveyCommandResponse>
    {
        public string SurveyId { get; set; }
    }
}
