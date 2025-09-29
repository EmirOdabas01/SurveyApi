using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Features.Commands.Survey.CreateSurvey;
using SurveyApi.Application.Features.Commands.Survey.RemoveSurvey;
using SurveyApi.Application.Features.Commands.Survey.UpdateSurvey;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurvey;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurveyForUsers;
using SurveyApi.Application.Features.Queries.Survey.GetSurveyById;
using SurveyApi.Application.Features.Queries.Survey.GetSurveyByIdDetail;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.RequestParameters;
using SurveyApi.Application.Services;
using SurveyApi.Application.ViewModels.Survey;

namespace SurveyApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        
        private readonly IFileService _fileService;
        private readonly IMediator _mediator;
        public SurveyController(ISurveyReadRepository surveyReadRepository,
           ISurveyWriteRepository surveyWriteRepository, 
            IFileService fileService,
            IMediator mediator)
        {
            
            _fileService = fileService;
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllSurvey([FromQuery] GetAllSurveyQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("get-all-foruser")]
        public async Task<IActionResult> GetAllSurveyForUser([FromQuery] GetAllSurveyForUsersQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetSurveyById([FromQuery] GetSurveyByIdQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("get-detail{id}")]
        public async Task<IActionResult> GetSUrveyByIdDetail([FromQuery] GetSurveyByIdDetailQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateSurveyCommandRequest request)
        {

            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSurvey([FromRoute] RemoveSurveyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateSurvey([FromBody] UpdateSurveyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("upload/{id}")]
        public async Task<IActionResult> Upload(string surveyıd)
        {
            var result =  await _fileService.UploadAsync("resources\\images", Request.Form.Files, surveyıd);

            return Ok(result);
        }
    }
}
