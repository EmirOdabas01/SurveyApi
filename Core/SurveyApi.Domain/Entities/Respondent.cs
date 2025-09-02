using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Respondent
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string EMail { get; set; }
        public required string PasswordHash { get; set; }
        public ICollection<Response> Responses { get; set; }
    }
}
