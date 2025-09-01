using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string EMail { get; set; }
        public required string PasswordHash { get; set; }
    }
}
