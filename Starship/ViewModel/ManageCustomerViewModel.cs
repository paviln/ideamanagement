using MvvmCross.ViewModels;
using Panel.Models;
using Starship.Command;
using Starship.Service;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Starship.ViewModel
{
    public class ManageCustomerViewModel : MvxViewModel
    {
        #region Propertise
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set { SetProperty(ref _companyName, value); }
        }
        private int _id;
 
        public int Id
        {
            get { return _id; }
            set {SetProperty(ref _id, value); }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }
        #endregion
        private readonly ICustomerService _customerService;
        //Constructor injection (IoC)
        public ManageCustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public ManageCustomerViewModel()
        {
            _customerService = new CustomerService();
            FillDataGrid();
            DeleteCustomerCmd = new AsyncCommand(ExecuteSubmitAsync, CanExecuteSubmit);
        }
        
        public IAsyncCommand DeleteCustomerCmd { get; private set; }

        private async Task ExecuteSubmitAsync()
        {
            try
            {
                await _customerService.DeleteCustomerAsync("15");
                MessageBox.Show("Test");
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

        private async void FillDataGrid()
        {
            var cust = await _customerService.GetCustomerAsync();
            foreach (var item in cust)
            {
                Customer customer = new Customer()
                {
                    CompanyName = item.CompanyName,
                    Id = item.Id

                };
                Customers.Add(customer);
            }
        }


    }
}
