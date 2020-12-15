using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.WPF.Command;
using EskobInnovation.IdeaManagement.WPF.Service;
using MvvmCross.ViewModels;
using Task = System.Threading.Tasks.Task;

namespace EskobInnovation.IdeaManagement.WPF.ViewModel
{
  public class UpdateCustomerViewModel : MvxViewModel
  {
    private readonly IApiCustomerService _apicustomerService;
    #region Propertise
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
      set { SetProperty(ref _id, value); }
    }
    private string _streetAddress;

    public string StreetAddress
    {
      get { return _streetAddress; }
      set { SetProperty(ref _streetAddress, value); }
    }
    private string _zipCode;

    public string ZipCode
    {
      get { return _zipCode; }
      set { SetProperty(ref _zipCode, value); }
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
    #endregion

    public UpdateCustomerViewModel(IApiCustomerService apiCustomerService)
    {
      _apicustomerService = apiCustomerService;
    }
    public UpdateCustomerViewModel()
    {
      _apicustomerService = new ApiCustomerService();
      UpdateCustomerCmd = new AsyncCommand(ExecuteSubmitAsyncUpdate, CanExecuteSubmit);
    }

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
          StreetAddress = StreetAddress,
          ZipCode = ZipCode,
          City = City, 
          ContactPerson = ContactPerson
        };
        await _apicustomerService.UpdateCustomerAsync(customer);
      }
      finally
      {
        IsBusy = false;
      }
    }
    #endregion
   
    private bool CanExecuteSubmit()
    {
      return !IsBusy;
    }

  }
}
