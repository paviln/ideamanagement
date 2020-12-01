using IdeaManagement.Domain.Models;
using System;
using System.Threading.Tasks;
/// <summary>
/// Class for validating
/// whether a customer exists
/// in the database or not
/// if it does not, create the customer.
/// </summary>
namespace IdeaManagement.Domain.Services.ValidateServices
{
    public class ValidateService : IValidateService
    {
        private readonly ICustomerService _customerService;
        public ValidateService(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<CustomerAddResult> AddCustomer(string customername)
        {
            CustomerAddResult result = CustomerAddResult.Success;
            
            Customer customerName = await _customerService.GetByCustomerName(customername);
            if(customerName != null)
            {
                result = CustomerAddResult.CustomerAlreadyExists;
            }
            if(result == CustomerAddResult.Success)
            {
                Customer customer = new Customer()
                {
                    CustomerName = customername
                };
                await _customerService.Create(customer);
            }
            return result;
        }
    }
}
