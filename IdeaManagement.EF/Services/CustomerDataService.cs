using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdeaManagement.Domain.Models;
using IdeaManagement.Domain.Services;
using IdeaManagement.EF.Common;
using Microsoft.EntityFrameworkCore;

namespace IdeaManagement.EF.Services
{

    public class CustomerDataService : ICustomerService
    {
        private readonly IdeaManagementContextFactory _contextFactory;
        private readonly WriteDataService<Customer> _writeDataService;

        public CustomerDataService(IdeaManagementContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _writeDataService = new WriteDataService<Customer>(contextFactory);
        }
        public async Task<Customer> Create(Customer entity)
        {
            return await _writeDataService.Create(entity);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            using (IdeaManagementDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Customer> entities = await context.Customers
                    .Include(c => c.CustomerName)
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<Customer> Update(int id, Customer entity)
        {
            return await _writeDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _writeDataService.Delete(id);
        }

        public async Task<Customer> Get(int id)
        {
            using (IdeaManagementDbContext context = _contextFactory.CreateDbContext())
            {
                Customer entity = await context.Customers
                    .Include(c => c.CustomerName)                    
                    .FirstOrDefaultAsync((c) => c.Id == id);
                return entity;
            }
        }

        public async Task<Customer> GetByCustomerName(string customername)
        {
            using (IdeaManagementDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Customers
                    .Include(c => c.CustomerName)                   
                    .FirstOrDefaultAsync(c => c.CustomerName == customername);
            }
        }

        public Task<IEnumerable<Customer>> GetAllCustomersl(int id, string customername)
        {
            throw new NotImplementedException();
        }
    }
}
