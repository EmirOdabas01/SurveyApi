using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Group.LeaveGroup
{
    public class LeaveGroupCommandRequest : IRequest<LeaveGroupCommandResponse>
    {
        public int GroupId { get; set; }
    }
}
