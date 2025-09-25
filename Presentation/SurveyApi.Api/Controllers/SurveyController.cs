using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Services;

namespace SurveyApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IFileService _fileService;
        public SurveyController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(string surveyıd)
        {
            var result =  await _fileService.UploadAsync("resources\\images", Request.Form.Files, surveyıd);

            return Ok(result);
        }
    }
}
