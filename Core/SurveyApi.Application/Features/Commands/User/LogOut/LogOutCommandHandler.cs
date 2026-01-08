using MediatR;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.User.LogOut
{
    public class LogOutCommandHandler : IRequestHandler<LogOutCommandRequest, LogOutCommandResponse>
    {
        private readonly IAuthService _authService;

        public LogOutCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LogOutCommandResponse> Handle(LogOutCommandRequest request, CancellationToken cancellationToken)
        {
            await _authService.LogOut();
            return new LogOutCommandResponse { };
        }
    }
}
