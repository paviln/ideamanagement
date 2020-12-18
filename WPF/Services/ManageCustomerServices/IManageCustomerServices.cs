using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;

namespace EskobInnovation.IdeaManagement.WPF.Services.ManageCustomerServices
{
  public enum RegistrationResultCustomer
  {
    Success,
    CustomerAlreadyExists,
    CustomerDoesNotExist
  }

  public interface IManageCustomerServices
  {
    Task<RegistrationResultCustomer> CreateCustomer(string companyname, string streetaddresse, string zipcode, string contactperson, string city);
    Task<RegistrationResultCustomer> UpdateCustomer(int id, string companyname, string streetaddress, string zipcode, string city, string contactperson);
    Task<RegistrationResultCustomer> DeleteCustomer(int id);
  }
}
