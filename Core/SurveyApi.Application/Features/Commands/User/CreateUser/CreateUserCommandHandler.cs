using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<Identity.User> _userManager;

        public CreateUserCommandHandler(UserManager<Identity.User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new Identity.User
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname,
                UserName = request.UserName,
                Email = request.EMail
            }, request.Password);

            CreateUserCommandResponse response = new() { Succeeded = result.Succeeded};

            if(response.Succeeded)
                response.Message = "New user created successfully";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} : {error.Description}\n";

            return response;
        }
    }
}
