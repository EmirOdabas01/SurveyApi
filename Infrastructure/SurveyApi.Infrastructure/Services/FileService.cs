using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      

        public async Task<(string path, string fileName)> UploadAsync(string path, IFormFileCollection file, string surveyId)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path); 

            if(!Path.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

          
            bool result = false;

            result = await CopyFileAsync($"{uploadPath}\\{surveyId}{Path.GetExtension(file[0].FileName)}", file[0]);

            if(result)
                return (path, $"{surveyId}{Path.GetExtension(file[0].FileName)}");

            return ("", "s");
        }
    }
}
