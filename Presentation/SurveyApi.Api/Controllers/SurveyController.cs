using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Features.Commands.Survey.CreateSurvey;
using SurveyApi.Application.Features.Commands.Survey.RemoveSurvey;
using SurveyApi.Application.Features.Commands.Survey.UpdateSurvey;
using SurveyApi.Application.Features.Commands.SurveyImage.UploadSurveyImage;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurvey;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurveyPrivateQuery;
using SurveyApi.Application.Features.Queries.Survey.GetSurveyById;
using SurveyApi.Application.Features.Queries.Survey.GetSurveyByIdDetail;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.RequestParameters;
using SurveyApi.Application.Services;
using SurveyApi.Application.ViewModels.Survey;

namespace SurveyApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        public async Task<IActionResult> GetAllSurveyPublic([FromRoute] GetAllSurveyQueryRequest getAllSurveyQueryRequest)
        {
            var result = await _mediator.Send(getAllSurveyQueryRequest);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSurveyPrivate([FromRoute] GetAllSurveyPrivateQueryRequest getAllSurveyPrivateQueryRequest)
        {
            var result = await _mediator.Send(getAllSurveyPrivateQueryRequest);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurveyById([FromRoute] GetSurveyByIdQueryRequest getSurveyByIdQueryRequest)
        {
            var result = await _mediator.Send(getSurveyByIdQueryRequest);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurveyByIdDetail([FromRoute] GetSurveyByIdDetailQueryRequest getSurveyByIdDetailQueryRequest)
        {
            var result = await _mediator.Send(getSurveyByIdDetailQueryRequest);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyCommandRequest createSurveyCommandRequest)
        {

            var result = await _mediator.Send(createSurveyCommandRequest);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveSurvey([FromRoute] RemoveSurveyCommandRequest removeSurveyCommandRequest)
        {
            var result = await _mediator.Send(removeSurveyCommandRequest);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSurvey([FromBody] UpdateSurveyCommandRequest updateSurveyCommandRequest)
        {
            var result = await _mediator.Send(updateSurveyCommandRequest);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadSurveyImage([FromQuery] UploadSurveyImageCommandRequest uploadSurveyImageCommandRequest)
        {
            uploadSurveyImageCommandRequest.Files = Request.Form.Files;
            var result = await _mediator.Send(uploadSurveyImageCommandRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSurveyImage()
        {
            return null;
        }
    }
}
