using SurveyApi.Application.DTOs;
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
    }
}
