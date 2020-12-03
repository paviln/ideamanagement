using IdeaManagement.Domain.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Starship.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Starship.ViewModel
{
    public class ManageCustomerViewModel : MvxViewModel
    {
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set { SetProperty(ref _customerName, value); }
        }
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }
        public void AddCustomers()
        {
            Customer c = new Customer
            {
                CustomerName = CustomerName
             };
            CustomerName = string.Empty;
         }

        public ManageCustomerViewModel()
        {
            Command = new AsyncCommand(ExecuteSubmitAsync, CanExecuteSubmit);
        }
        public IAsyncCommand Command { get; private set; }

        private async Task ExecuteSubmitAsync()
        {
            try
            {
                IsBusy = true;
                Execute();
                //CustomerAddResult customerAddResult = await _validateService.AddCustomer(CustomerName);

            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanExecuteSubmit()
        {
            return !IsBusy;
        }
        public ICommand test { get; }

        private void Execute()
        {
            MessageBox.Show("Test");
        }

    }
}
