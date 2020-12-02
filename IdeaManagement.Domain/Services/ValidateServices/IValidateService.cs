using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManagement.Domain.Services.ValidateServices
{
    public enum CustomerAddResult
    {
        Success,
        CustomerAlreadyExists
    }
    public interface IValidateService
    {
        /// <summary>
        /// Add a new Customer
        /// </summary>
        /// <param name="customername"></param>
        /// <returns></returns>
        Task<CustomerAddResult> AddCustomer(string customername);

    }
}
