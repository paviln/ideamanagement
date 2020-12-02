using IdeaManagement.Domain.Services;
using MvvmCross.ViewModels;
using Starship.Commands;
using Starship.State.Validator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
/// <summary>
/// Class will be refactored
/// </summary>
namespace Starship.ViewModel
{
    public class AddCustomerViewModel : MvxViewModel
    {
        private string _customerName;
        public AddCustomerViewModel()
        {

        }

        public string CustomerName
        {
            get { return _customerName; }
            set { SetProperty(ref _customerName, value); }
        }
        public ICommand AddCustomerCommand { get; }
        public AddCustomerViewModel(IValidator validator)
        {
            AddCustomerCommand = new AddCustomerCommand(this, validator);
        }
    }
}
