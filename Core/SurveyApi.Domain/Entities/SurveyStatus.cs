using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyApi.Domain.Enums;
namespace SurveyApi.Domain.Entities
{
    public class SurveyStatus
    {
        public Guid Id { get; set; }
        public Status SurveyStats { get; set; }
        public ICollection<Survey> Surveys { get; set; }
    }
}
