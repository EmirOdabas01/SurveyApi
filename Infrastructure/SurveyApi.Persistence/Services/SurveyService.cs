using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.DTOs.Survey;
using SurveyApi.Application.DTOs.SurveyImage;
using SurveyApi.Application.Enums;
using SurveyApi.Application.Exceptions;
using SurveyApi.Application.Features.Commands.Survey.CloseSurvey;
using SurveyApi.Application.Features.Commands.Survey.CreateSurvey;
using SurveyApi.Application.Features.Commands.Survey.PublishSurvey;
using SurveyApi.Application.Features.Commands.Survey.RemoveSurvey;
using SurveyApi.Application.Features.Commands.Survey.UpdateSurvey;
using SurveyApi.Application.Features.Commands.SurveyImage.RemoveSurveyImage;
using SurveyApi.Application.Features.Commands.SurveyImage.UploadSurveyImage;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurvey;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurveyCreatedByUser;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurveyForGroups;
using SurveyApi.Application.Features.Queries.Survey.GetAllSurveyPrivateQuery;
using SurveyApi.Application.Features.Queries.Survey.GetSurveyById;
using SurveyApi.Application.Features.Queries.Survey.GetSurveyByIdDetail;
using SurveyApi.Application.Features.Queries.SurveyImage.GetSurveyImage;
using SurveyApi.Application.Repositories;
using SurveyApi.Domain.Entities;
using SurveyApi.Domain.Entities.Identity;
using SurveyApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Persistence.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyWriteRepository _surveyWriteRepository;
        private readonly ISurveyReadRepository _surveyReadRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IGroupReadRepository _groupReadRepository;
        private readonly IConfiguration _configuration;
        private readonly IAnswerWriteRepository _answerWriteRepository;
        private readonly IImageFileWriteRepository _ımageFileWriteRepository;
        private readonly IImageFileReadRepository _ımageFileReadRepository;
        private readonly IFileService _fileService;
        public SurveyService(ISurveyWriteRepository surveyWriteRepository, 
            ISurveyReadRepository surveyReadRepository, 
            IHttpContextAccessor httpContextAccessor, 
            UserManager<User> userManager,
            IGroupReadRepository groupReadRepository,
            IConfiguration configuration,
            IAnswerWriteRepository answerWriteRepository,
            IImageFileReadRepository ımageFileReadRepository,
            IImageFileWriteRepository ımageFileWriteRepository,
            IFileService fileService)
        {
            _surveyWriteRepository = surveyWriteRepository;
            _surveyReadRepository = surveyReadRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _groupReadRepository = groupReadRepository;
            _configuration = configuration;
            _answerWriteRepository = answerWriteRepository;
            _ımageFileReadRepository = ımageFileReadRepository;
            _ımageFileWriteRepository = ımageFileWriteRepository;
            _fileService = fileService;
        }

        private async Task<User> ContextUser()
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
                throw new Exception("Unknown Error");

            var user = await _userManager.Users.Where(u => u.UserName == userName)
                .Include(u => u.Surveys)
                .ThenInclude(s => s.ImageFile)
                .Include(u => u.Surveys)
                .ThenInclude(s => s.Visibility)
                .Include(u => u.Surveys)
                .ThenInclude(s => s.SurveyStatus)
                .FirstOrDefaultAsync();
               
            if (user == null)
                throw new UserNotFoundException();

            return user;
        }
        public async Task CreateSurveyAsync(CreateSurveyDto model)
        {
            var user = await ContextUser();

            await _surveyWriteRepository.AddAsync(new Domain.Entities.Survey
            {
                UserId = user.Id,
                Name = model.Name,
                Description = model.Description,
                MinResponse = model.MinResponse,
                MaxResponse = model.MaxResponse,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                VisibilityId = Convert.ToInt32(model.Visibility),
            });

            await _surveyWriteRepository.SaveAsync();
        }

        public async Task<GetAllSurveyResponseDto> GetAllSurveyAsync(GetAllSurveyRequestDto model)
        {
            var surveys = await _surveyReadRepository.GetAll(false)
               .Where(s => s.Visibility.State == VisibilityStat.Public.ToString() && s.SurveyStatus.SurveyStatuse == Status.Open.ToString())
               .Skip(model.Size * model.Page)
               .Take(model.Size)
               .Select(s => new {
                   Id = s.SurveyId,
                   Name = s.Name,
                   Description = s.Description,
               }).ToListAsync();

            int count = surveys.Count();
            return new()
            {
                Count = count,
                Surveys = surveys
            };
        }

        public async Task<GetAllSurveyResponseDto> GetAllSurveyForGroupAsync()
        {
            var user = await ContextUser();

            var userGroups = await _groupReadRepository
               .Table
               .Include(g => g.Users)
               .ThenInclude(u => u.Surveys)  
               .ToListAsync();

            var groupsOfUser = userGroups
                .Where(g => g.Users.Any(u => u.Id == user.Id))
                .ToList();

            var groupSurveyPairs = groupsOfUser
                .Select(g => new
                {
                    GroupName = g.Name,
                    Surveys = g.Users
                        .Where(u => u.Id != user.Id)  
                        .SelectMany(u => u.Surveys)
                        .Select(s => new
                        {
                            s.SurveyId,
                            s.Name,
                            s.Description
                        })
                        .ToList()
                })
                .Where(g => g.Surveys.Any())  
                .ToList();

            return new GetAllSurveyResponseDto
            {
                Count = groupSurveyPairs.Sum(g => g.Surveys.Count),
                Surveys = groupSurveyPairs.Select(g => new
                {
                    g.GroupName,
                    Surveys = g.Surveys
                })
            };
        }

        public async Task<GetAllSurveyResponseDto> GetAllSurveyPrivateAsync(GetAllSurveyRequestDto model)
        {

            var surveys = await _surveyReadRepository.GetAll(false)
              .Where(s => s.Visibility.State == VisibilityStat.Private.ToString() && s.SurveyStatus.SurveyStatuse == Status.Open.ToString())
              .Skip(model.Size * model.Page)
              .Take(model.Size)
              .Select(s => new {
                  Id = s.SurveyId,
                  Name = s.Name,
                  Description = s.Description,
              }).ToListAsync();

            int count = surveys.Count();
            return new()
            {
                Count = count,
                Surveys = surveys
            };
        }

        public async Task<GetSurveyByIdResponseDto> GetSurveyByIdAsync(string Id)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(Id, false);

            if (survey == null)
                throw new Exception();

            return new()
            {
                Id = survey.SurveyId.ToString(),
                Name = survey.Name,
                Description = survey.Description,
            };
        }

        public async Task<GetSurveyByIdDetailResponseDto> GetSurveyByIdDetailAsync(string Id)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(Id, false);

            return new()
            {
                Id = survey.SurveyId.ToString(),
                Name = survey.Name,
                Description = survey.Description,
                MinResponse = survey.MinResponse,
                MaxResponse = survey.MaxResponse,
                StartDate = survey.StartDate,
                EndDate = survey.EndDate,
            };
        }

        public async Task<GetSurveyImageResponseDto> GetSurveyImageAsync(string SurveyId)
        {
            var survey = await _surveyReadRepository.Table.Include(s => s.ImageFile).FirstOrDefaultAsync(p => p.SurveyId == Guid.Parse(SurveyId));

            if (survey == null)
                throw new Exception();

            return new()
            {
                Id = survey.SurveyId.ToString(),
                Path = $"{_configuration["BaseStorageUrl"]}/{survey.ImageFile.Path}",
            };
        }

        public async Task<GetAllSurveyResponseDto> GetUserSurveysAsync()
        {
            var user = await ContextUser();

            var surveys = user.Surveys?.Select(s => new
            {
              Id = s.SurveyId,
              Name = s.Name,
              Description = s.Description,
              StartDate = s.StartDate,
              EndDate = s.EndDate,
              MinResponse = s.MinResponse,
              MaxResponse = s.MaxResponse,
              Visibility = s.Visibility.State,
              State = s.SurveyStatus.SurveyStatuse,
              Path = s.ImageFile?.Path
            }).ToList();

            GetAllSurveyResponseDto response = new()
            {
                Count = surveys.Count,
                Surveys = surveys
            };
            return response;
        }

        public async Task RemoveSurveyAsync(string Id)
        {
            var survey = await _surveyReadRepository.GetWhere(s => s.SurveyId == Guid.Parse(Id))
               .Include(s => s.SurveyStatus)
               .Include(s => s.Questions)
               .ThenInclude(q => q.Answers)
               .FirstOrDefaultAsync();


            if (survey == null)
                throw new Exception();

            if (survey.SurveyStatus.SurveyStatuse != Status.Planned.ToString())
            {
                var questions = survey.Questions.ToList();

                foreach (var question in questions)
                {
                    var answerList = question.Answers.ToList();
                    _answerWriteRepository.RemoveRange(answerList);
                }

                await _answerWriteRepository.SaveAsync();
            }

            await _surveyWriteRepository.RemoveAsync(Id);
            await _surveyWriteRepository.SaveAsync();
        }

        public async Task RemoveSurveyImageAsync(int Id)
        {
            var imageFile = await _ımageFileReadRepository.GetByIdAsync(Id);

            if (imageFile != null)
                await _ımageFileWriteRepository.RemoveAsync(Id);
        }

        public async Task UpdateSurveyAsync(UpdateSurveyDto model)
        {
            var survey = await _surveyReadRepository.GetWhere(s => s.SurveyId == Guid.Parse(model.Id))
                .Include(s => s.SurveyStatus)
                .FirstOrDefaultAsync();

            if (survey?.SurveyStatus.SurveyStatuse != Status.Planned.ToString())
                throw new Exception();

            survey.Name = model.Name;
            survey.Description = model.Description;
            survey.MinResponse = model.MinResponse;
            survey.MaxResponse = model.MaxResponse;
            survey.StartDate = model.StartDate;
            survey.EndDate = model.EndDate;
            survey.VisibilityId = Convert.ToInt32(model.Visibility);

            await _surveyWriteRepository.SaveAsync();
        }

        public async Task UploadSurveyImageAsync(UploadSurveyImageDto model)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(model.Id, false);

            if (survey == null)
                throw new Exception();

            var result = await _fileService.UploadAsync("resources\\images", model.Files, model.Id);

            await _ımageFileWriteRepository.AddAsync(new Domain.Entities.ImageFile
            {
                SurveyId = Guid.Parse(model.Id),
                Path = result.path,
                FileName = result.fileName
            });

            await _ımageFileWriteRepository.SaveAsync();
        }

        public async Task<bool> PublishSurveyAsync(string Id)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(Id);

            if (survey == null)
                throw new SurveyNotFoundException();

            survey.SurveyStatusId = (int)Status.Open;
            int success = await _surveyWriteRepository.SaveAsync();

            if (success > 0)
                return true;

            return false;
        }

        public async Task<bool> CloseSurveyAsync(string Id)
        {
            var survey = await _surveyReadRepository.GetByIdAsync(Id);

            if (survey == null)
                throw new SurveyNotFoundException();

            survey.SurveyStatusId = (int)Status.Closed;
            int success = await _surveyWriteRepository.SaveAsync();

            if (success > 0)
                return true;

            return false;
        }
    }
}
