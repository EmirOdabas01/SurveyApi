using SurveyApi.Application.DTOs.Survey;
using SurveyApi.Application.DTOs.SurveyImage;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Abstractions.Services
{
    public interface ISurveyService
    {
        Task CreateSurveyAsync(CreateSurveyDto model);
        Task UpdateSurveyAsync(UpdateSurveyDto model);
        Task RemoveSurveyAsync(string Id);
        Task<GetAllSurveyResponseDto> GetAllSurveyAsync(GetAllSurveyRequestDto model);
        Task<GetAllSurveyResponseDto> GetAllSurveyPrivateAsync(GetAllSurveyRequestDto model);
        Task<GetAllSurveyResponseDto> GetUserSurveysAsync();
        Task<GetAllSurveyResponseDto> GetAllSurveyForGroupAsync();
        Task<GetSurveyByIdDetailResponseDto> GetSurveyByIdDetailAsync(string Id);
        Task<GetSurveyByIdResponseDto> GetSurveyByIdAsync(string Id);
        Task RemoveSurveyImageAsync(int Id);
        Task UploadSurveyImageAsync(UploadSurveyImageDto model);
        Task<GetSurveyImageResponseDto> GetSurveyImageAsync(string SurveyId);
        Task<bool> PublishSurveyAsync(string Id);
        Task<bool> CloseSurveyAsync(string Id);

    }
}
