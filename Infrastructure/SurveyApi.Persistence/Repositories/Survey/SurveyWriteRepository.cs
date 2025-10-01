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
    public class SurveyWriteRepository : WriteRepository<Survey>, ISurveyWriteRepository
    {
        public SurveyWriteRepository(SurveyApiDbContext context) : base(context)
        {
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var entity = await Table.FirstOrDefaultAsync(data => data.SurveyId == Guid.Parse(id));
            return Remove(entity);
        }
    }
}
