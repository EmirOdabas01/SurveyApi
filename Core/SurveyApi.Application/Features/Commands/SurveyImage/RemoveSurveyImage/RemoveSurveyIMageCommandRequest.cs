using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.SurveyImage.RemoveSurveyImage
{
    public class RemoveSurveyIMageCommandRequest : IRequest<RemoveSurveyIMageCommandResponse>
    {
        public int Id { get; set; }
    }
}
