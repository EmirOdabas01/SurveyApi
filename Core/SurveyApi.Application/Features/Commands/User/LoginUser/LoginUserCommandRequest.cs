using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string NameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
