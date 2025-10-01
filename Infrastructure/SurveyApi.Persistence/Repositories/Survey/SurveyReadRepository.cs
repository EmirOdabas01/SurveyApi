using Microsoft.EntityFrameworkCore;
using SurveyApi.Application.Repositories;
using SurveyApi.Domain.Entities;
using SurveyApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Persistence.Repositories
{
    public class SurveyReadRepository : ReadRepository<Survey>, ISurveyReadRepository
    {
        public SurveyReadRepository(SurveyApiDbContext context) : base(context)
        {
        }

        public async Task<Survey> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = Table.AsNoTracking();
            return await Table.FindAsync(Guid.Parse(id));
        }

        public IQueryable<Survey> GetWhere(Expression<Func<Survey, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);

            if (!tracking)
                query = Table.AsNoTracking();
            return query;
        }
    }
}
