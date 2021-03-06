﻿using MvvmCross.ViewModels;
using EskobInnovation.IdeaManagement.WPF.Command;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.WPF.Services.RegistrationServices;
using EskobInnovation.IdeaManagement.WPF.Services.ManageCustomerServices;
using System.Windows;
using EskobInnovation.IdeaManagement.API.Models;
using Task = System.Threading.Tasks.Task;
/// <summary>
/// 
/// </summary>
namespace EskobInnovation.IdeaManagement.WPF.ViewModel
{
  public class RegistrationViewModel : MvxViewModel
  {
    private readonly IRegistrationService _registrationService;
    private readonly IManageCustomerServices _manageCustomerService;

    #region Properties
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
    private string _email;

    public string Email
    {
      get { return _email; }
      set { SetProperty(ref _email, value); }
    }

    private string _password;
    public string Password
    {
      get { return _password; }
      set { SetProperty(ref _password, value); }
    }
    private int _siteId;
    public int SiteId
    {
      get { return _siteId; }
      set { SetProperty(ref _siteId, value); }
    }
    private string _name;
    public string Name
    {
      get { return _name; }
      set { SetProperty(ref _name, value); }
    }
    private string _position;
    public string Position
    {
      get { return _position; }
      set { SetProperty(ref _position, value); }
    }
    #endregion
    #region Constructors
    //Constructor Injection - dependency injection - (IoC)
    public RegistrationViewModel(IRegistrationService registrationService, IManageCustomerServices manageCustomerServices)
    {
      _registrationService = registrationService;
      _manageCustomerService = manageCustomerServices;
    }
    public RegistrationViewModel()
    {
      _registrationService = new RegistrationService();
      _manageCustomerService = new ManageCustomerServices();
      AddCustomerCmd = new AsyncCommand(ExecuteSubmitAsyncCustomer, CanExecuteSubmit);
      CreateAccountCmd = new AsyncCommand(ExecuteSubmitAsyncAccount, CanExecuteSubmit);
    }
    #endregion
    #region IAsyncCommands
    public IAsyncCommand AddCustomerCmd { get; private set; }
    public IAsyncCommand CreateAccountCmd { get; private set; }
    #endregion

    #region Async Executes
    public async Task ExecuteSubmitAsyncCustomer()
    {
      try
      {
        RegistrationResultCustomer registrationResult = await _manageCustomerService.CreateCustomer(CompanyName, StreetAddress, ZipCode, ContactPerson, City);
        this.CompanyName = string.Empty;
        this.StreetAddress = string.Empty;
        this.ZipCode = string.Empty;
        this.ContactPerson = string.Empty;
        this.City = string.Empty;
        MessageBox.Show("The Customer registration was a: " + registrationResult);
      }
      finally
      {
        IsBusy = false;
      }
    }
    public async Task ExecuteSubmitAsyncAccount()
    {
      try
      {

        RegistrationResult registrationResult = await _registrationService.Register(Email, Password, Name, Position, SiteId);
        this.Email = string.Empty;
        this.Password = string.Empty;
        MessageBox.Show("The account registration was a: " + registrationResult);
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
