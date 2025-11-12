using MediatR;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Group.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommandRequest, CreateGroupCommandResponse>
    {
        private readonly IGroupService _groupService;

        public CreateGroupCommandHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<CreateGroupCommandResponse> Handle(CreateGroupCommandRequest request, CancellationToken cancellationToken)
        {
            await _groupService.CreateGroupAsync(new DTOs.Group.CreateGroupDto
            {
                Name = request.Name,
                Description = request.Description
            });
            return new();
        }
    }
}
