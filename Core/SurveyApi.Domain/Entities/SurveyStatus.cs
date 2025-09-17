using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SurveyApi.Domain.Entities
{
    public class SurveyStatus : BaseEntity
    {
        public string SurveyStatuse { get; set; }
        public ICollection<Survey> Surveys { get; set; }
    }
}
