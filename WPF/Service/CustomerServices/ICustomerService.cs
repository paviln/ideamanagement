using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;

namespace EskobInnovation.IdeaManagement.WPF.Service
{
  public enum CreationResult
  {
    Success,
    CustomerNameAlreadyExists,
  }
  public interface ICustomerService
  {
    Task<IEnumerable<Customer>> GetCustomerAsync(int id);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<Uri> CreateCustomerAsync(string companyname, string streetaddresse, string zipcode, string contactperson);
    Task<Customer> UpdateCustomerAsync(Customer customer);
    Task<HttpStatusCode> DeleteCustomerAsync(string id);
  }
}
