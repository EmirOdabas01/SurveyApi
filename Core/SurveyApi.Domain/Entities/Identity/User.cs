using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities.Identity
{
    public class User : IdentityUser<string>
    {
        public string NameSurname { get; set; }
        public ICollection<Survey> Surveys { get; set; }
    }
}
