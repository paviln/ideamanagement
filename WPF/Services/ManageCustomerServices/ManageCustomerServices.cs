using System;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Service;

namespace EskobInnovation.IdeaManagement.WPF.Services.ManageCustomerServices
{
  public class ManageCustomerServices : IManageCustomerServices
  {
    private readonly IApiCustomerService _customerService;

    public ManageCustomerServices(IApiCustomerService customerService)
    {
      _customerService = customerService;
    }

    public ManageCustomerServices()
    {
      _customerService = new ApiCustomerService();
    }

    public async Task<RegistrationResultCustomer> CreateCustomer(string companyname, string streetaddresse, string zipcode, string contactperson)
    {
      RegistrationResultCustomer result = RegistrationResultCustomer.Success;


      //var name = _customerService.GetByName(companyname);
      //if(name != null)
      //{
      //  result = RegistrationResultCustomer.CustomerAlreadyExists;
      //}



      if(result == RegistrationResultCustomer.Success)
      {
        Customer customer = new Customer()
        {
          CompanyName = companyname,
          StreetAdresse = streetaddresse,
          ZipCode = zipcode,
          ContactPerson = contactperson
        };

        await _customerService.CreateCustomerAsync(customer);

      }
      return result;
     
    }

    public Task<RegistrationResultCustomer> DeleteCustomer(string id)
    {
      throw new NotImplementedException();
    }

    public Task<RegistrationResultCustomer> UpdateCustomer(string id)
    {
      throw new NotImplementedException();
    }
  }
}
