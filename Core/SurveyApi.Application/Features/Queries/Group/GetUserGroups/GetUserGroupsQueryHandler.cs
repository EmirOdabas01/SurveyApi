using MediatR;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Group.GetUserGroups
{
    public class GetUserGroupsQueryHandler : IRequestHandler<GetUserGroupsQueryRequest, GetUserGroupsQueryResponse>
    {
        private readonly IGroupService _groupService;

        public GetUserGroupsQueryHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GetUserGroupsQueryResponse> Handle(GetUserGroupsQueryRequest request, CancellationToken cancellationToken)
        {
            var userGroups = await _groupService.GetUserGroupsAsync();
            return new GetUserGroupsQueryResponse
            {
                Count = userGroups.Count,
                Groups = userGroups.Groups
            };
        }
    }
}
