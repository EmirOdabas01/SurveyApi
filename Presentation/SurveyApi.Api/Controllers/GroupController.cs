using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Features.Commands.Group.CreateGroup;
using SurveyApi.Application.Features.Commands.Group.EnrollToGroup;
using SurveyApi.Application.Features.Commands.Group.LeaveGroup;
using SurveyApi.Application.Features.Queries.Group.GetAllGroups;
using SurveyApi.Application.Features.Queries.Group.GetUserGroups;

namespace SurveyApi.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserGroups(GetUserGroupsQueryRequest getUserGroupsQueryRequest)
        {
            var response = await _mediator.Send(getUserGroupsQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups(GetAllGroupsQueryRequest getAllGroupsQueryRequest)
        {
            var response = await _mediator.Send(getAllGroupsQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupCommandRequest createGroupCommandRequest)
        {
            var response = await _mediator.Send(createGroupCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> EnrollToGroup(EnrollGroupCommandRequest enrollGroupCommandRequest)
        {
            var response = await _mediator.Send(enrollGroupCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> LeaveGroup(LeaveGroupCommandRequest leaveGroupCommandRequest)
        {
            var response = await _mediator.Send(leaveGroupCommandRequest);
            return Ok(response);
        }
    }
}
