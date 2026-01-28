using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Features.Commands.Question.CreateQuestions;
using SurveyApi.Application.Features.Commands.Question.DeleteQuestions;
using SurveyApi.Application.Features.Commands.Question.RemoveSingleQuestion;
using SurveyApi.Application.Features.Commands.Question.UpdateQuestions;
using SurveyApi.Application.Features.Queries.Question.GetAllQuestions;

namespace SurveyApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> CreateSurveyQuestions([FromBody] CreateQuestionsCommandRequest createQuestionsCommandRequest)
        {
            var reponse = await _mediator.Send(createQuestionsCommandRequest);
            return Ok(reponse);
        }

        [HttpGet("{SurveyId}")]
        public async Task<IActionResult> GetSurveyQuestions([FromRoute]GetAllQuestionQueryRequest getAllQuestionQueryRequest)
        {
            var reponse = await _mediator.Send(getAllQuestionQueryRequest);
            return Ok(reponse);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> UpdateSurveyQuestions([FromBody] UpdateQuestionsCommandRequest updateQuestionsCommandRequest)
        {
            var reponse = await _mediator.Send(updateQuestionsCommandRequest);
            return Ok(reponse);
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> RemoveSurveyQuestions([FromQuery] RemoveQuestionsCommandRequest removeQuestionsCommandRequest)
        {
            var response = await _mediator.Send(removeQuestionsCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> RemoveSingleQuestion([FromQuery] RemoveSingleQuestionCommandRequest removeSingleQuestionCommandRequest)
        {
            var response = await _mediator.Send(removeSingleQuestionCommandRequest);
            return Ok(response);
        }
    }
}
