using Azure.Core;
using Microsoft.AspNetCore.Identity;
using SurveyApi.Application.Abstractions;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.DTOs;
using SurveyApi.Application.Exceptions;
using SurveyApi.Application.Features.Commands.User.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Identity = SurveyApi.Domain.Entities.Identity;
namespace SurveyApi.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Identity.User> _userManager;
        private readonly SignInManager<Identity.User> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        public AuthService(SignInManager<Identity.User> signInManager,
            UserManager<Identity.User> userManager,
            ITokenHandler tokenHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }
        public async Task<Token> LoginAsync(string nameOrEmail, string password, int tokenLifeTime)
        {
            var user = await _userManager.FindByNameAsync(nameOrEmail);

            if (user == null)
                user = await _userManager.FindByEmailAsync(nameOrEmail);

            if (user == null)
                throw new UserNotFoundException();

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                var token = _tokenHandler.AccessToken(tokenLifeTime);
                return token;
            }

            throw new AuthenticationErrorException();
        }
    }
}
