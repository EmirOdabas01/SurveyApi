using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Survey.GetSurveyByIdDetail
{
    public class GetSurveyByIdDetailQueryRequest : IRequest<GetSurveyByIdDetailQueryResponse>
    {
        public string Id { get; set; }
    }
}
