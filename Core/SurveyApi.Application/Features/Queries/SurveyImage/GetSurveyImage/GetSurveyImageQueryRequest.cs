using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.SurveyImage.GetSurveyImage
{
    public class GetSurveyImageQueryRequest : IRequest<GetSurveyImageQueryResponse>
    {
        public string Id { get;set; }
    }
}
