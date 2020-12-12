using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        private string  _streetAdresse;

        public  string StreetAdresse
        {
            get { return _streetAdresse; }
            set { SetProperty(ref _streetAdresse, value); }
        }
        private string _zipCode;

        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode ,value); }
        }

        private string _contactPerson;

        public string ContactPerson
        {
          get { return _contactPerson; }
          set { SetProperty(ref _contactPerson, value); }

        }

    public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { SetProperty(ref _customers, value); }
        }
        #endregion
        private readonly IApiCustomerService _customerService;
        //Constructor injection (IoC)
        public ManageCustomerViewModel(IApiCustomerService customerService)
        {
            _customerService = customerService;
        }
        public ManageCustomerViewModel()
        {
            _customerService = new ApiCustomerService();
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
                    CompanyName = CompanyName,
                };

             await _customerService.UpdateCustomerAsync(customer);
            this.CompanyName = string.Empty;
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
                var customers = await _customerService.GetCustomersAsync();
                
                foreach (var item in customers)
                {
                    Customer customer = new Customer()
                    {
                        CompanyName = item.CompanyName,
                        Id = item.Id,
                        StreetAdresse = item.StreetAdresse,
                        ZipCode = item.ZipCode,
                        ContactPerson = item.ContactPerson
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
