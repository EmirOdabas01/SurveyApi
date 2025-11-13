using SurveyApi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Domain.Entities
{
    public class Survey : BaseEntity
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }
        public Guid SurveyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MinResponse { get; set; }
        public int MaxResponse { get; set; }
        public SurveyStatus SurveyStatus { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Response> Responses { get; set; } 
        public ImageFile ImageFile { get; set; }
        public Visibility Visibility { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public int VisibilityId { get; set; }
        public int SurveyStatusId { get; set; }
    }
}
