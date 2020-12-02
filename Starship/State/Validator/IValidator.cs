using System;
using IdeaManagement.Domain.Services.ValidateServices;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Starship.State.Validator
{
    public interface IValidator
    {
        event Action StateChanged;

        Task<CustomerAddResult> AddCustomer(string customername);
    }
}
