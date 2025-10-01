using SurveyApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApi.Application.Repositories
{
    public interface ISurveyReadRepository : IReadRepository<Survey>
    {
        Task<Survey> GetByIdAsync(string id, bool tracking = true);
        IQueryable<Survey> GetWhere(Expression<Func<Survey, bool>> method, bool tracking = true);
    }
}
