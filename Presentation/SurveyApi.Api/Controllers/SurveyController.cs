using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Features.Commands.Survey.CreateSurvey;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurvey;
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
        private readonly ISurveyReadRepository _surveyReadRepository;
        private readonly ISurveyWriteRepository _surveyWriteRepository;
        private readonly IFileService _fileService;
        private readonly IMediator _mediator;
        public SurveyController(ISurveyReadRepository surveyReadRepository,
           ISurveyWriteRepository surveyWriteRepository, 
            IFileService fileService,
            IMediator mediator)
        {
            _surveyReadRepository = surveyReadRepository;
            _surveyWriteRepository = surveyWriteRepository;
            _fileService = fileService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllSurveyQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreateSurveyCommandRequest request)
        {

            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(string surveyıd)
        {
            var result =  await _fileService.UploadAsync("resources\\images", Request.Form.Files, surveyıd);

            return Ok(result);
        }
    }
}
