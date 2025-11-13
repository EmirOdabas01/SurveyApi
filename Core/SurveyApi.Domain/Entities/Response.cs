using SurveyApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Response : BaseEntity
    {
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public  ICollection<Answer> Answers { get; set; }
        public  Survey Survey { get; set; }
        public User User { get; set; }

        public string? UserId { get; set; }
        public Guid SurveyId { get; set; }
    }
}
