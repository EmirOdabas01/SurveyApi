using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Services
{
    public interface IFileService
    {
        Task<string> UploadAsync(string path, IFormFileCollection file, string surveyId);
        Task<bool> CopyFileAsync(string path, IFormFile file);
    }
}
