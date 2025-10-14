using SurveyApi.Application.DTOs.User;
using SurveyApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseDto> CreateAsync(CreateUserRequestDto model);
        Task UpdateRefreshToken(string refreshToken, User user, DateTime accessTokenDate, int minutes);
    }
}
