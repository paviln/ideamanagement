using IdeaManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
/// <summary>
/// A common class for
/// NonQuery Methods
/// </summary>
namespace IdeaManagement.EF.Common
{
    public class WriteDataService<T> where T : DomainObject
    {
        private readonly IdeaManagementContextFactory _contextFactory;

        public WriteDataService(IdeaManagementContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (IdeaManagementDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (IdeaManagementDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (IdeaManagementDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
