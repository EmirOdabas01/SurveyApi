using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class User : BaseEntity
    {
        public required string UsesrName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string EMail { get; set; }
        public required string PasswordHash { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Survey> Surveys { get; set; }
        public ICollection<Response> Responses { get; set; }
    }
}
