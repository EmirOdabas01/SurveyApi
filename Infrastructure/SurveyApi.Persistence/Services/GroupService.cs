using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Abstractions.Services;
using SurveyApi.Application.DTOs.Group;
using SurveyApi.Application.Exceptions;
using SurveyApi.Application.Repositories;
using SurveyApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Persistence.Services
{
    public class GroupService : IGroupService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IGroupWriteRepository _groupWriteRepository;
        private readonly IGroupReadRepository _groupReadRepository;
        public GroupService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager,
            IGroupReadRepository groupReadRepository,
            IGroupWriteRepository groupWriteRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _groupReadRepository = groupReadRepository;
            _groupWriteRepository = groupWriteRepository;
        }

        private async Task<User> ContextUser()
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
                throw new Exception("Unknown Error");

            var user = await _userManager.Users.Where(u => u.UserName == userName)
                .Include(u => u.Groups)
                .FirstOrDefaultAsync();

            if (user == null)
                throw new UserNotFoundException();

            return user;
        }
        public async Task CreateGroupAsync(CreateGroupDto model)
        {
            var user = await ContextUser();
            user.Groups.Add(new Domain.Entities.Group
            {
                Name = model.Name,
                Description = model.Description,
            });

            await _userManager.UpdateAsync(user);   
        }

        public async Task EnrollGroupAsync(int GroupId)
        {
            var user = await ContextUser();
            var group = await _groupReadRepository.GetByIdAsync(GroupId);

            if (group == null)
                throw new GroupNotFoundException();

            user.Groups.Add(group);
            await _userManager.UpdateAsync(user);
        }

        public async Task<GroupListDto> GetAllGroupsAsync()
        {
            var user = await ContextUser();
            var groupIds = user.Groups.Select(g => g.Id).ToList();

            var groups = await _groupReadRepository.GetWhere(g => !groupIds.Contains(g.Id)).ToListAsync();

            return new GroupListDto
            {
                Count = groups.Count(),
                Groups =  groups.Select(g => new
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                })
            };
        }

        public async Task<GroupListDto> GetUserGroupsAsync()
        {
            var user = await ContextUser();

            return new GroupListDto
            {
                Count = user.Groups.Count,
                Groups = user.Groups.Select(g => new
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                }).ToList()
            };
        }

        public async Task LeaveGroupAsync(int GroupId)
        {
            var user = await ContextUser();
            var group = await _groupReadRepository.GetByIdAsync(GroupId);

            if (group == null)
                throw new GroupNotFoundException();

            user.Groups.Remove(group);
            await _userManager.UpdateAsync(user);

            var groupWithMembers = await _groupReadRepository.GetWhere(g => g.Id == GroupId).Include(g => g.Users).FirstOrDefaultAsync();

            if (groupWithMembers?.Users.Count == 0)
                 await _groupWriteRepository.RemoveAsync(GroupId);

            await _groupWriteRepository.SaveAsync();

        }
    }
}
