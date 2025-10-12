using SurveyApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Abstractions
{
    public interface ITokenHandler
    {
        Token AccessToken(int minutes);
    }
}
