using IdeaManagement.Domain.Services.ValidateServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Starship.State.Validator
{
    public class Validator : IValidator
    {
        private readonly IValidateService _validateService;

        public event Action StateChanged;
        public Validator(IValidateService validateService)
        {
            _validateService = validateService;
        }
        public async Task<CustomerAddResult> AddCustomer(string customername)
        {
            return await _validateService.AddCustomer(customername);
        }
    }
}
