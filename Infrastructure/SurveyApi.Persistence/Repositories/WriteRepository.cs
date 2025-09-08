using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly SurveyApiDbContext _context;

        public WriteRepository(SurveyApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            var entityEntry = await Table.AddAsync(model);
            return  entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Remove(T model)
        {
            var entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var entity = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(entity);
        }

        public bool RemoveRange(List<T> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

        public bool Update(T model)
        {
            var entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
