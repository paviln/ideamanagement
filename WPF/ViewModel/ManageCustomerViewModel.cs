using MvvmCross.ViewModels;
using EskobInnovation.IdeaManagement.WPF.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EskobInnovation.IdeaManagement.API.Models;

namespace EskobInnovation.IdeaManagement.WPF.ViewModel
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


    }
}
