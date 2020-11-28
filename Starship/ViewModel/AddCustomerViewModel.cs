using MvvmCross.ViewModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Starship.ViewModel
{
    public class AddCustomerViewModel : MvxViewModel
    {
        //private ObservableCollection<CustomerDTO> _customer = new ObservableCollection<CustomerDTO>();


        //public ObservableCollection<CustomerDTO> Customer
        //{
        //    get { return _customer; }
        //    set { SetProperty(ref _customer, value); }
        //}

        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set { SetProperty(ref _customerName, value); }
        }
        public ICommand Command { get; }
        public AddCustomerViewModel()
        {
            Command = new CommandViewModel(Execute);
        }

        private void Execute()
        {
            string sql = "insert into Customer (CustomerName) values (@CustomerName);";
            
            //MessageBox.Show(CustomerName);
        }
     

    }
}
