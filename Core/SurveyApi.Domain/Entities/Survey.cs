using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Survey : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Visibility { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MinResponse { get; set; }
        public int MaxResponse { get; set; }
        public SurveyStatus SurveyStatus { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Response> Responses { get; set; } 
        public User User { get; set; }
        public ImageFile ImageFile { get; set; }
    }
}
