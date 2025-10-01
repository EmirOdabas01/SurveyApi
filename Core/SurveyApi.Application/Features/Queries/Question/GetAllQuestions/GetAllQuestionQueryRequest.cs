using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Question.GetAllQuestions
{
    public class GetAllQuestionQueryRequest : IRequest<GetAllQuestionQueryResponse>
    {
        public string SurveyId { get; set; }
    }
}
