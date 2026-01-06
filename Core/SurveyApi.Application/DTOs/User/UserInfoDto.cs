using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.DTOs.User
{
    public class UserInfoDto
    {
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
    }
}
