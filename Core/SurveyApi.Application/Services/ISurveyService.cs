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

namespace SurveyApi.Application.Services
{
    public interface ISurveyService
    {
        Task<CreateSurveyCommandResponse> CreateSurveyAsync(CreateSurveyCommandRequest model);
        Task<UpdateSurveyCommandResponse> UpdateSurveyAsync(UpdateSurveyCommandRequest model);
        Task<RemoveSurveyCommandResponse> RemoveSurveyAsync(RemoveSurveyCommandRequest model);
        Task<GetAllSurveyQueryResponse> GetAllSurveyAsync(GetAllSurveyQueryRequest model);
        Task<GetAllSurveyPrivateQueryResponse> GetAllSurveyPrivateAsync(GetAllSurveyPrivateQueryRequest model);
        Task<GetAllSurveyCreatedByUserQueryResponse> GetUserSurveysAsync(GetAllSurveyCreatedByUserQueryRequest model);
        Task<GetAllSurveyForGroupsQueryResponse> GetAllSurveyForGroupAsync(GetAllSurveyForGroupsQueryRequest model);
        Task<GetSurveyByIdDetailQueryResponse> GetSurveyByIdDetailAsync(GetSurveyByIdDetailQueryRequest model);
        Task<GetSurveyByIdQueryResponse> GetSurveyByIdAsync(GetSurveyByIdQueryRequest model);
        Task<RemoveSurveyIMageCommandResponse> RemoveSurveyImageAsync(RemoveSurveyIMageCommandRequest model);
        Task<UploadSurveyImageCommandResponse> UploadSurveyImageAsync(UploadSurveyImageCommandRequest model);
        Task<GetSurveyImageQueryResponse> GetSurveyImageAsync(GetSurveyImageQueryRequest model);
        Task<PublishSurveyCommandResponse> PublishSurveyAsync(PublishSurveyCommandRequest model);
        Task<CloseSurveyCommandResponse> CloseSurveyAsync(CloseSurveyCommandRequest model);

    }
}
