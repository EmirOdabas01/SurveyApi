using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Features.Commands.User.LoginUser;
using SurveyApi.Application.Features.Commands.User.LogOut;
using SurveyApi.Application.Features.Commands.User.RefreshTokenLogin;
using SurveyApi.Application.Features.Queries.User.UserInfo;

namespace SurveyApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            var response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest )
        {
            var response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Me()
        {
            var response = await _mediator.Send(new UserInfoQueryRequest { });
            return Ok(response);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> LogOut()
        {
            var response = await _mediator.Send(new LogOutCommandRequest { });
            return Ok(response);
        }
    }
}
