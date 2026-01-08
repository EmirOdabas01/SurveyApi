using SurveyApi.Application.DTOs;
using SurveyApi.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<Token> LoginAsync(string nameOrEmail, string password, int tokenLifeTime);
        Task<Token> LoginRefreshTokenAsync(string refreshToken);
        Task<UserInfoDto?> GetUserInfo();
        Task LogOut();

    }
}
