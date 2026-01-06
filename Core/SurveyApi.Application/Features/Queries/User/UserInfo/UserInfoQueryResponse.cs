using SurveyApi.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.User.UserInfo
{
    public class UserInfoQueryResponse
    {
       public UserInfoDto? UserInfo { get; set; }
    }
}
