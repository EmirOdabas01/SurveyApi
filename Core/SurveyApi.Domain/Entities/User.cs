using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UsesrName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Survey> Surveys { get; set; }
        public ICollection<Response> Responses { get; set; }
    }
}
