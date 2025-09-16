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
    public class GroupReadRepository : ReadRepository<Group>, IGroupReadRepository
    {
        public GroupReadRepository(SurveyApiDbContext context) : base(context)
        {
        }
    }
}
