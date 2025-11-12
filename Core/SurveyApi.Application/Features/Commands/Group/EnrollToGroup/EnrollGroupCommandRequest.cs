using MediatR;
using SurveyApi.Application.Features.Commands.Group.LeaveGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Group.EnrollToGroup
{
    public class EnrollGroupCommandRequest : IRequest<EnrollGroupCommandResponse>
    {
        public int GroupId { get; set; }
    }
}
