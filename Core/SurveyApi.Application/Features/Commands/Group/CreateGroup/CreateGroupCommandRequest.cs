using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Group.CreateGroup
{
    public class CreateGroupCommandRequest : IRequest<CreateGroupCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
