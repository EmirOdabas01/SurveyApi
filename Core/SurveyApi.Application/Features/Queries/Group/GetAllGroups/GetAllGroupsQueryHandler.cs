using MediatR;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Group.GetAllGroups
{
    public class GetAllGroupsQueryHandler : IRequestHandler<GetAllGroupsQueryRequest, GetAllGroupsQueryResponse>
    {
        private readonly IGroupService _groupService;

        public GetAllGroupsQueryHandler(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<GetAllGroupsQueryResponse> Handle(GetAllGroupsQueryRequest request, CancellationToken cancellationToken)
        {
            var groupList = await _groupService.GetAllGroupsAsync();
            return new GetAllGroupsQueryResponse
            {
                Count = groupList.Count,
                Groups = groupList.Groups
            };
        }
    }
}
