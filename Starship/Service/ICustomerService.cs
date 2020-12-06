using Panel.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Starship.Service
{
    public interface  ICustomerService
    {
        Task<List<Customer>> GetCustomerAsync();

        Task<Uri> CreateCustomerAsync(string companyname);

        Task<Customer> UpdateCustomerAsync(Customer customer);

        Task<HttpStatusCode> DeleteCustomerAsync(string id);
        
    }
}
