using Azure.Core;
using Microsoft.AspNetCore.Identity;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.DTOs.User;
using SurveyApi.Application.Features.Commands.User.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Identity = SurveyApi.Domain.Entities.Identity;
namespace SurveyApi.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<Identity.User> _userManager;
        public UserService(UserManager<Identity.User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<CreateUserResponseDto> CreateAsync(CreateUserRequestDto model)
        {
            IdentityResult result = await _userManager.CreateAsync(new Identity.User
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = model.NameSurname,
                UserName = model.UserName,
                Email = model.EMail,
            }, model.Password);

            CreateUserResponseDto response = new() { Succeeded = result.Succeeded };

            if (response.Succeeded)
                response.Message = "New user created successfully";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} : {error.Description}\n";

            return response;
        }
    }
}
