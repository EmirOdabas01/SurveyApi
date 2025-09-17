using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.ViewModels.User
{
    public class VM_Update_User
    {
        public string Id { get; set; }
        public string UserName { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public string EMail { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}
