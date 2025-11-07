using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.SurveyImage
{
    public class UploadSurveyImageDto
    {
        public string Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
