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
        public Guid SurveyStatusId { get; set; }
        public Status SurveyStats { get; set; }
    }
}
