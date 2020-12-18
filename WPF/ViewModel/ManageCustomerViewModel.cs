using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Service;
using EskobInnovation.IdeaManagement.WPF.Command;
using System;
using Task = System.Threading.Tasks.Task;
using EskobInnovation.IdeaManagement.WPF.View.Windows;
using System.Windows;
using System.Windows.Input;

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
    private Customer _selectedElement;
    public Customer SelectedElement
    {
      get { return _selectedElement; }
      set {SetProperty(ref _selectedElement, value);}
    }
    #endregion
    private readonly IApiCustomerService _apicustomerService;
        //Constructor injection (IoC)
    public ManageCustomerViewModel(IApiCustomerService apiCustomerService)
    {
        _apicustomerService = apiCustomerService;
    }
    public ManageCustomerViewModel()
    {
      _apicustomerService = new ApiCustomerService();
      DeleteCustomerCmd = new AsyncCommand(ExecuteSubmitAsyncDelete, CanExecuteSubmit);
      ShowUpdateCustomerWindowCmd = new SyncCommandBase(ExecuteUpdateWindow);
      ShowUrlWindowCmd = new SyncCommandBase(ExecuteURLWindow);
      FillDataGrid();
    }
    #region DeleteCommand And Execute
    public IAsyncCommand DeleteCustomerCmd { get; private set; }

    private async Task ExecuteSubmitAsyncDelete()
    {
      try
    {
      await _apicustomerService.DeleteCustomerAsync(SelectedElement.Id);
      MessageBox.Show("Deleted Customer with ID : " + SelectedElement.Id);
    }
      finally
      {
        IsBusy = false;
      }
    }
    #endregion
    #region UpdateCommand and Execute
    public ICommand ShowUpdateCustomerWindowCmd { get; private set; }
    public ICommand ShowUrlWindowCmd { get; private set; }
    private void ExecuteURLWindow()
    {
      Window window = new CreateUrlWindow();
      window.Show();
    }
    private void ExecuteUpdateWindow()
    {
      Window window = new UpdateCustomerWindow();
      window.Show();
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
