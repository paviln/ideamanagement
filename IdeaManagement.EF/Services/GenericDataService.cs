using IdeaManagement.Domain.Models;
using IdeaManagement.Domain.Services;
using IdeaManagement.EF.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
/// <summary>
/// GenericDataService 
/// will handle all CRUD operations
/// for all Domain objects
/// implements IDataService
/// where the generic type T
/// is DomainObject
/// </summary>
namespace IdeaManagement.EF.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly IdeaManagementContextFactory _contextFactory;
        private readonly WriteDataService<T> _writeDataService;
        public GenericDataService(IdeaManagementContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _writeDataService = new WriteDataService<T>(contextFactory);
            
        }
        /// <summary>
        /// Method for creating an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Create(T entity)
        {
            return await _writeDataService.Create(entity);
        }
        /// <summary>
        /// Method for deleting an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            return await _writeDataService.Delete(id); ;
        }
        /// <summary>
        /// Method for fetching an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> Get(int id)
        {
            using (IdeaManagementDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }
        /// <summary>
        /// Method for fetching all entities
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            using (IdeaManagementDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }
        /// <summary>
        /// Method for updating an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Update(int id, T entity)
        {
            return await _writeDataService.Update(id,entity);
        }
    }
}
