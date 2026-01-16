using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Features.Commands.Survey.CloseSurvey;
using SurveyApi.Application.Features.Commands.Survey.CreateSurvey;
using SurveyApi.Application.Features.Commands.Survey.PublishSurvey;
using SurveyApi.Application.Features.Commands.Survey.RemoveSurvey;
using SurveyApi.Application.Features.Commands.Survey.UpdateSurvey;
using SurveyApi.Application.Features.Commands.SurveyImage.RemoveSurveyImage;
using SurveyApi.Application.Features.Commands.SurveyImage.UploadSurveyImage;
using SurveyApi.Application.Features.Queries.Survey.AnalyzeSurvey;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurvey;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurveyCreatedByUser;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurveyForGroups;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurveyPrivateQuery;
using SurveyApi.Application.Features.Queries.Survey.GetSurveyById;
using SurveyApi.Application.Features.Queries.Survey.GetSurveyByIdDetail;
using SurveyApi.Application.Features.Queries.SurveyImage.GetSurveyImage;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.RequestParameters;
using SurveyApi.Application.ViewModels.Survey;

namespace SurveyApi.Api.Controllers
{
    // [Authorize(AuthenticationSchemes = "Admin")]
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
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetAllSurveyPrivate([FromRoute] GetAllSurveyPrivateQueryRequest getAllSurveyPrivateQueryRequest)
        {
            var result = await _mediator.Send(getAllSurveyPrivateQueryRequest);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetAllSurveysForGroups()
        {
            var result = await _mediator.Send(new GetAllSurveyForGroupsQueryRequest { });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurveyById([FromRoute] GetSurveyByIdQueryRequest getSurveyByIdQueryRequest)
        {
            var result = await _mediator.Send(getSurveyByIdQueryRequest);
            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetSurveyByIdDetail([FromRoute] GetSurveyByIdDetailQueryRequest getSurveyByIdDetailQueryRequest)
        {
            var result = await _mediator.Send(getSurveyByIdDetailQueryRequest);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyCommandRequest createSurveyCommandRequest)
        {

            var result = await _mediator.Send(createSurveyCommandRequest);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> RemoveSurvey([FromRoute] RemoveSurveyCommandRequest removeSurveyCommandRequest)
        {
            var result = await _mediator.Send(removeSurveyCommandRequest);
            return Ok(result);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> UpdateSurvey([FromBody] UpdateSurveyCommandRequest updateSurveyCommandRequest)
        {
            var result = await _mediator.Send(updateSurveyCommandRequest);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> UploadSurveyImage([FromQuery] UploadSurveyImageCommandRequest uploadSurveyImageCommandRequest)
        {
            uploadSurveyImageCommandRequest.Files = Request.Form.Files;
            var result = await _mediator.Send(uploadSurveyImageCommandRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSurveyImage([FromQuery] GetSurveyImageQueryRequest getSurveyImageQueryRequest)
        {
            var response = await _mediator.Send(getSurveyImageQueryRequest);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> RemoveSurveyImage([FromQuery] RemoveSurveyIMageCommandRequest removeSurveyIMageCommandRequest)
        {
            var response = await _mediator.Send(removeSurveyIMageCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> GetUserSurveys([FromRoute]GetAllSurveyCreatedByUserQueryRequest getAllSurveyCreatedByUserQueryRequest)
        {
            var response = await _mediator.Send(getAllSurveyCreatedByUserQueryRequest);
            return Ok(response);
        }

        [HttpPut("{SurveyId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> PublishSurvey([FromRoute] PublishSurveyCommandRequest publishSurveyCommandRequest)
        {
            var response = await _mediator.Send(publishSurveyCommandRequest);
            return Ok(response);
        }

        [HttpPut("{SurveyId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> CloseSurvey([FromRoute] CloseSurveyCommandRequest closeSurveyCommandRequest)
        {
            var response = await _mediator.Send(closeSurveyCommandRequest);
            return Ok(response);
        }

        [HttpGet("{SurveyId}")]
        public async Task<IActionResult> AnalyzeSurvey([FromRoute] AnalyzeSurveyQueryRequest analyzeSurveyQueryRequest)
        {
            var response = await _mediator.Send(analyzeSurveyQueryRequest);
            return Ok(response);
        }
    }
}
