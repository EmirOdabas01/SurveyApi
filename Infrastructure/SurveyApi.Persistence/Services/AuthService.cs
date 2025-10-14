using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserService _userService;
        public AuthService(SignInManager<Identity.User> signInManager,
            UserManager<Identity.User> userManager,
            ITokenHandler tokenHandler,
            IUserService userService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
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
                var token = _tokenHandler.CreateAccessToken(tokenLifeTime);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 20);
                return token;
            }

            throw new AuthenticationErrorException();
        }

        public async Task<Token> LoginRefreshTokenAsync(string refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if(user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                var token = _tokenHandler.CreateAccessToken(20);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 20);
                return token;
            }
            else
                throw new UserNotFoundException();
        }
    }
}
