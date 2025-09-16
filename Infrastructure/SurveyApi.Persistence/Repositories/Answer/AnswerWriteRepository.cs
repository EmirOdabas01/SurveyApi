using Microsoft.EntityFrameworkCore;
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
    public class AnswerWriteRepository : WriteRepository<Answer>, IAnswerWriteRepository
    {
        public AnswerWriteRepository(SurveyApiDbContext context) : base(context)
        {
        }
    }
}
