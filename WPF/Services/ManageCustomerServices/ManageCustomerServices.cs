using System;
using System.Linq;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Service;
using EskobInnovation.IdeaManagement.WPF.ViewModel;

namespace EskobInnovation.IdeaManagement.WPF.Services.ManageCustomerServices
{
  public class ManageCustomerServices : IManageCustomerServices
  {
    private readonly IApiCustomerService _customerService;
    private readonly ManageCustomerViewModel _manageCustomerViewModel;
    public ManageCustomerServices(IApiCustomerService customerService, ManageCustomerViewModel manageCustomerViewModel)
    {
      _customerService = customerService;
      _manageCustomerViewModel = manageCustomerViewModel;
    }

    public ManageCustomerServices()
    {
      _customerService = new ApiCustomerService();
      _manageCustomerViewModel = new ManageCustomerViewModel();
    }

    public async Task<RegistrationResultCustomer> CreateCustomer(string companyname, string streetaddresse, string zipcode, string contactperson, string city)
    {
      RegistrationResultCustomer result = RegistrationResultCustomer.Success;

      var name = _manageCustomerViewModel.Customers.SingleOrDefault(c => c.CompanyName == companyname); 
      if (name != null)
      {
        result = RegistrationResultCustomer.CustomerAlreadyExists;
      }

      if (result == RegistrationResultCustomer.Success)
      {
         Customer customer = new Customer()
        {
          CompanyName = companyname,
          StreetAddress = streetaddresse,
          ZipCode = zipcode,
          ContactPerson = contactperson,
          City = city
        };

        await _customerService.CreateCustomerAsync(customer);

      }
      return result;
     
    }

    public async Task<RegistrationResultCustomer> DeleteCustomer(int id)
    {
      RegistrationResultCustomer result = RegistrationResultCustomer.Success;

      var cust_id = _manageCustomerViewModel.Customers.SingleOrDefault(c => c.Id == id);

      if (cust_id.Id == id)
      {
        result = RegistrationResultCustomer.CustomerAlreadyExists;
      }

      if (cust_id.Id != id)
      {
        await _customerService.DeleteCustomerAsync(id);
      }

      return result;
      
    }

    public async Task<RegistrationResultCustomer> UpdateCustomer(int id, string companyname)
    {
      RegistrationResultCustomer result = RegistrationResultCustomer.Success;

      var cust_id = _manageCustomerViewModel.Customers.SingleOrDefault(c => c.Id == id);

      if (cust_id.Id != id)
      {
        result = RegistrationResultCustomer.CustomerDoesNotExist;
      }

      if (cust_id.Id == id)
      {
        Customer customer = new Customer()
        {
          Id = id,
          CompanyName = companyname
        };

        await _customerService.UpdateCustomerAsync(customer);
      }

      return result;
    }
  }
}
