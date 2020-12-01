using IdeaManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManagement.Domain.Services
{
    public interface ICustomerService : IDataService<Customer>
    {
        Task<Customer> GetByCustomerName(string customername);
    }
}
