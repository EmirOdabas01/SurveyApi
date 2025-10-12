using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<Identity.User> _userManager;
        private readonly SignInManager<Identity.User> _signInManager;

        public LoginUserCommandHandler(SignInManager<Identity.User> signInManager,
            UserManager<Identity.User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.NameOrEmail);

            if (user == null)
                user = await _userManager.FindByEmailAsync(request.NameOrEmail);

            if (user == null)
                throw new UserNotFoundException();

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if(result.Succeeded)
            {

            }
            return new();
        }
    }
}
