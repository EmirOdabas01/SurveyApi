using MediatR;
using SurveyApi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.User.UserInfo
{
    public class UserInfoQueryHandler : IRequestHandler<UserInfoQueryRequest, UserInfoQueryResponse>
    {
        private readonly IAuthService _authService;

        public UserInfoQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<UserInfoQueryResponse> Handle(UserInfoQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _authService.GetUserInfo();
            return new UserInfoQueryResponse
            {
                UserInfo = response
            };
        }
    }
}
