using SurveyApi.Application.DTOs.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Abstractions.Services
{
    public interface IGroupService
    {
        Task CreateGroupAsync(CreateGroupDto model);
        Task EnrollGroupAsync(int GroupId);
        Task LeaveGroupAsync(int GroupId);
        Task<GroupListDto> GetUserGroupsAsync();
        Task<GroupListDto> GetAllGroupsAsync();
    }
}
