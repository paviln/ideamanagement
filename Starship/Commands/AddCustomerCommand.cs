using IdeaManagement.Domain.Models;
using IdeaManagement.Domain.Services;
using IdeaManagement.Domain.Services.ValidateServices;
using IdeaManagement.EF.Services;
using Starship.State.Validator;
using Starship.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Starship.Commands
{
    public class AddCustomerCommand : CommandBase
    {
        private readonly AddCustomerViewModel _addCustomerViewModel;
        private readonly IValidator _validator;
        
        public AddCustomerCommand(AddCustomerViewModel addCustomerViewModel, IValidator validator)
        {
            _addCustomerViewModel = addCustomerViewModel;
            _validator = validator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            MessageBox.Show("Im clicked");
            try
            {
                CustomerAddResult customerAddResult  = await _validator.AddCustomer(
                    _addCustomerViewModel.CustomerName);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Customer Already Exists");
            }
         }
    }
}
