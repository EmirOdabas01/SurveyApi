using MediatR;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Group.LeaveGroup
{
    public class LeaveGroupCommandHandler : IRequestHandler<LeaveGroupCommandRequest, LeaveGroupCommandResponse>
    {
        private readonly IGroupService _groupService;

        public LeaveGroupCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<LeaveGroupCommandResponse> Handle(LeaveGroupCommandRequest request, CancellationToken cancellationToken)
        {
            await _groupService.LeaveGroupAsync(request.GroupId);
            return new();
        }
    }
}
