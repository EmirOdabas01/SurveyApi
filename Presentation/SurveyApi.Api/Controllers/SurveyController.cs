using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
       
        public SurveyController(ISurveyReadRepository surveyReadRepository,
           ISurveyWriteRepository surveyWriteRepository, 
            IFileService fileService)
        {
            _surveyReadRepository = surveyReadRepository;
            _surveyWriteRepository = surveyWriteRepository;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Pagination pagination)
        {
            var result =  _surveyReadRepository.GetAll(false).Skip(pagination.Size * pagination.Page).Take(pagination.Size).Select(s => new
            {
                s.Id,
                s.Name,
                s.Description,
                s.MinResponse,
                s.MaxResponse,
                s.StartDate,
                s.EndDate,
                s.ImageFile.Path,
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody] VM_Create_Survey model)
        {
            var result = await _surveyWriteRepository.AddAsync(new Domain.Entities.Survey
            {

                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                MinResponse = model.MinResponse,
                MaxResponse = model.MaxResponse,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Visibility = model.Visibility.ToString(),
                UserId = Guid.Parse(model.UserId)
                
            });
            var final = await _surveyWriteRepository.SaveAsync();
            return Ok(final);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(string surveyıd)
        {
            var result =  await _fileService.UploadAsync("resources\\images", Request.Form.Files, surveyıd);

            return Ok(result);
        }
    }
}
