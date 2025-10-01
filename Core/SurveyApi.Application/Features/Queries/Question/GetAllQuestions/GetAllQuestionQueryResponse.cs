using SurveyApi.Application.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Features.Queries.Question.GetAllQuestions
{
    public class GetAllQuestionQueryResponse
    {
        public string SurveyId { get; set; }
        public List<VM_Read_Question>? Questions { get; set; }
    }
}
