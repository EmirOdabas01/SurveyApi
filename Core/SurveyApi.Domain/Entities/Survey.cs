using SurveyApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Survey
    {
        public Guid SurveyId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required Visibility Visibility { get; set; }
        public required DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MinResponse { get; set; }
        public int MaxResponse { get; set; }
    }
}
