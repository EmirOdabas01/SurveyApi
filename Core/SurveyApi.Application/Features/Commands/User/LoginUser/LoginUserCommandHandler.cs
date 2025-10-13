using MediatR;
using Microsoft.AspNetCore.Identity;
using SurveyApi.Application.Abstractions;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.DTOs;
using SurveyApi.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identity = SurveyApi.Domain.Entities.Identity;
namespace SurveyApi.Application.Features.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _authService.LoginAsync(request.NameOrEmail, request.Password, 20);
            return new LoginUserSuccessResponse() { AccessToken = response };
        }
    }
}
