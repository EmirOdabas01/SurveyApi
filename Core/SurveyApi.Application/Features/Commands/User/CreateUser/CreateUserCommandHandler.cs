using MediatR;
using Microsoft.AspNetCore.Identity;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity = SurveyApi.Domain.Entities.Identity;
namespace SurveyApi.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.CreateAsync(new()
            {
                NameSurname = request.NameSurname,
                UserName = request.UserName,
                EMail = request.EMail,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm
            });

            return new()
            {
                Succeeded = response.Succeeded,
                Message = response.Message
            };
        }
    }
}
