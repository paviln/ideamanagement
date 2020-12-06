using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
    public interface  ICustomerService
    {
        Task<List<Customer>> GetCustomerAsync();

        Task<Uri> CreateCustomerAsync(string companyname);

        Task<Customer> UpdateCustomerAsync(Customer customer);

        Task<HttpStatusCode> DeleteCustomerAsync(string id);
        
    }
}
