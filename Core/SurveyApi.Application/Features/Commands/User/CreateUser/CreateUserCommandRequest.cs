using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string NameSurname { get; set; } 
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
