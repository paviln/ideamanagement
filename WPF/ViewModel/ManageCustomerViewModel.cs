using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Service;
using EskobInnovation.IdeaManagement.WPF.Command;
using System;

namespace EskobInnovation.IdeaManagement.WPF.ViewModel
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
        private string  _streetAddresse;

        public  string StreetAddresse
        {
            get { return _streetAddresse; }
            set { SetProperty(ref _streetAddresse, value); }
        }
        private string _zipCode;

        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode ,value); }
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
            UpdateCustomerCmd = new AsyncCommand(ExecuteSubmitAsyncUpdate, CanExecuteSubmit);
        }
        #region DeleteCommand And Execute
        public IAsyncCommand DeleteCustomerCmd { get; private set; }

        private async Task ExecuteSubmitAsync()
        {
            try
            {
                await _customerService.DeleteCustomerAsync(Id.ToString());
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion

        #region UpdateCommand and Execute
        public IAsyncCommand UpdateCustomerCmd { get; private set; }

        private async Task ExecuteSubmitAsyncUpdate()
        {
            try
            {
                Customer customer = new Customer()
                {
                    Id = Id,
                    CompanyName = CompanyName
                };

                await _customerService.UpdateCustomerAsync(customer);

            }
            finally
            {
                IsBusy = false;
            }
        }


        #endregion


        #region implicit methods
        private bool CanExecuteSubmit()
        {
            return !IsBusy;
        }
        private async void FillDataGrid()
        {
            try
            {
                var cust = await _customerService.GetCustomerAsync();
                
                foreach (var item in cust)
                {
                    Customer customer = new Customer()
                    {
                        CompanyName = item.CompanyName,
                        Id = item.Id,
                        StreetAdresse = item.StreetAdresse,
                        ZipCode = item.ZipCode
                    };
                    Customers.Add(customer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        #endregion
    }

}
