using SurveyApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandResponse
    {
    }

    public class LoginUserSuccessResponse : LoginUserCommandResponse
    {
        public Token AccessToken { get; set; }
    }

    public class LoginUserFailureResponse : LoginUserCommandResponse
    {
        public string ErrorMessage { get; set; }
    } 
}