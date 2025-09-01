using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Response
    {
        public Guid ResponseId { get; set; }
        public required DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
