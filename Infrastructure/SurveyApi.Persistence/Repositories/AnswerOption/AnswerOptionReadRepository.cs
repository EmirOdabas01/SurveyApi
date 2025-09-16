using SurveyApi.Application.Repositories;
using SurveyApi.Domain.Entities;
using SurveyApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Persistence.Repositories
{
    public class AnswerOptionReadRepository : ReadRepository<AnswerOption>, IAnswerOptionReadRepository
    {
        public AnswerOptionReadRepository(SurveyApiDbContext context) : base(context)
        {
        }
    }
}
