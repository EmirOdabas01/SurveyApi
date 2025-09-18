using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApi.Application.Repositories;
using SurveyApi.Application.ViewModels.User;
using SurveyApi.Domain.Entities;

namespace SurveyApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserReadRepository _userReadRepo;
        private readonly IUserWriteRepository _userWriteRepo;

        public UserController(IUserReadRepository userReadRepo, IUserWriteRepository userWriteRepo)
        {
            _userReadRepo = userReadRepo;
            _userWriteRepo = userWriteRepo;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var users =  _userReadRepo.GetAll();
            return Ok(users.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userReadRepo.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(VM_Update_User newUser)
        {
            var user = await _userReadRepo.GetByIdAsync(newUser.Id);
            user.UsesrName = newUser.UserName;
            user.PhoneNumber = newUser.PhoneNumber;
            user.EMail = newUser.EMail;

            await _userWriteRepo.SaveAsync();
            return Ok(user);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var final = await _userWriteRepo.RemoveAsync(id);
            await _userWriteRepo.SaveAsync();
            return Ok(final);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(VM_Create_User user)
        {
            User newUser = new User
            {
                Id = Guid.NewGuid(),
                UsesrName = user.UserName,
                EMail = user.EMail,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.Password,
            };

            var result = await _userWriteRepo.AddAsync(newUser);
            await _userWriteRepo.SaveAsync();
            return Ok(result);
        }
    }
}
