using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Service;
using EskobInnovation.IdeaManagement.WPF.Command;
using System;
using EskobInnovation.IdeaManagement.WPF.Services.ManageCustomerServices;

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
        private string  _streetAddress;

        public  string StreetAddress
        {
            get { return _streetAddress; }
            set { SetProperty(ref _streetAddress, value); }
        }
        private string _zipCode;

        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode ,value); }
        }
        private string _city;

        public string City
        {
          get { return _city; }
          set { SetProperty(ref _city, value); }
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
    private readonly IApiCustomerService _apicustomerService;
    //private readonly IManageCustomerServices _customerService;
        //Constructor injection (IoC)
        public ManageCustomerViewModel( IApiCustomerService apiCustomerService)
        {
            //_customerService = customerService;
            _apicustomerService = apiCustomerService;
        }
        public ManageCustomerViewModel()
        {
           // _customerService = new ManageCustomerServices();
            _apicustomerService = new ApiCustomerService();
            FillDataGrid();
            DeleteCustomerCmd = new AsyncCommand(ExecuteSubmitAsyncDelete, CanExecuteSubmit);
            UpdateCustomerCmd = new AsyncCommand(ExecuteSubmitAsyncUpdate, CanExecuteSubmit);
        }
        #region DeleteCommand And Execute
        public IAsyncCommand DeleteCustomerCmd { get; private set; }

        private async Task ExecuteSubmitAsyncDelete()
        {
            try
            {
              await _apicustomerService.DeleteCustomerAsync(Id);
           // await _customerService.DeleteCustomer(Id);
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

              await _apicustomerService.UpdateCustomerAsync(customer);
            //await _customerService.UpdateCustomer(Id, CompanyName);
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
        public async void FillDataGrid()
        {
            try
            {
                var customers = await _apicustomerService.GetCustomersAsync();
                
                foreach (var item in customers)
                {
                    Customer customer = new Customer()
                    {
                        CompanyName = item.CompanyName,
                        Id = item.Id,
                        StreetAddress = item.StreetAddress,
                        ZipCode = item.ZipCode,
                        City = item.City,
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
