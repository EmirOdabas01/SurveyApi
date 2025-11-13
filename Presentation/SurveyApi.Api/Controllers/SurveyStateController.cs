using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Features.Commands.Answers;
using SurveyApi.Application.Features.Commands.Response;

namespace SurveyApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SurveyStateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SurveyStateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{SurveyId}")]
        public async Task<IActionResult> StartSurvey([FromRoute] StartSurveyCommandRequest startSurveyCommandRequest)
        {
            var response = await _mediator.Send(startSurveyCommandRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitAnswers([FromBody] SubmitAnswersCommandRequest submitAnswersCommandRequest)
        {
            var response = await _mediator.Send(submitAnswersCommandRequest);
            return Ok(response);
        }
    }
}
