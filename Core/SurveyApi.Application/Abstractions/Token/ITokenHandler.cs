using SurveyApi.Application.DTOs;
using SurveyApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Abstractions
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int minutes, User user);
        string CreateRefreshToken();
    }
}
