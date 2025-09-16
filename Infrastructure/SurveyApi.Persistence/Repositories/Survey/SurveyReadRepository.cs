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
    public class SurveyReadRepository : ReadRepository<Survey>, ISurveyReadRepository
    {
        public SurveyReadRepository(SurveyApiDbContext context) : base(context)
        {
        }
    }
}
