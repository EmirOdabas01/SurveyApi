using MediatR;
using SurveyApi.Application.Enums;
using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Commands.Survey.CreateSurvey
{
    public class CreateSurveyCommandRequest : IRequest<CreateSurveyCommandResponse>
    {
        public string UserId { get; set; }
        public string SurveyStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Visibility Visibility { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MinResponse { get; set; }
        public int MaxResponse { get; set; }
    }
}
