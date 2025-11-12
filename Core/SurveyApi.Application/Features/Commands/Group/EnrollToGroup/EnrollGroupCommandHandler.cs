using MediatR;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Features.Commands.Group.LeaveGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Group.EnrollToGroup
{
    public class EnrollGroupCommandHandler : IRequestHandler<EnrollGroupCommandRequest, EnrollGroupCommandResponse>
    {
        private readonly IGroupService _groupService;

        public EnrollGroupCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<EnrollGroupCommandResponse> Handle(EnrollGroupCommandRequest request, CancellationToken cancellationToken)
        {
            await _groupService.EnrollGroupAsync(request.GroupId);
            return new();
        }
    }
}
