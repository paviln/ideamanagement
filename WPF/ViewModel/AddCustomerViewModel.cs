using MvvmCross.ViewModels;
using EskobInnovation.IdeaManagement.WPF.Command;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.WPF.Service.SiteServices;
using EskobInnovation.IdeaManagement.WPF.Services.RegistrationServices;
using EskobInnovation.IdeaManagement.WPF.Services.ManageCustomerServices;
using EskobInnovation.IdeaManagement.WPF.Services.SiteServices;
using System.Windows;
/// <summary>
/// 
/// </summary>
namespace EskobInnovation.IdeaManagement.WPF.ViewModel
{
  public class AddCustomerViewModel : MvxViewModel
  {
    private readonly IRegistrationService _registrationService;
    private readonly IManageCustomerServices _manageCustomerService;
    private readonly ISiteServices _siteService;

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

    private string _link;

    public string Link
    {
      get { return _link; }
      set { _link = value; }
    }


    #endregion
    #region Constructors
    //Constructor Injection - dependency injection - (IoC)
    public AddCustomerViewModel(ISiteServices siteServices, IRegistrationService registrationService, IManageCustomerServices manageCustomerServices)
    {
      _siteService = siteServices;
      _registrationService = registrationService;
      _manageCustomerService = manageCustomerServices;
    }
    public AddCustomerViewModel()
    {
      _siteService = new SiteServices();
      _registrationService = new RegistrationService();
      _manageCustomerService = new ManageCustomerServices();
      AddCustomerCmd = new AsyncCommand(ExecuteSubmitAsyncCustomer, CanExecuteSubmit);
      CreateAccountCmd = new AsyncCommand(ExecuteSubmitAsyncAccount, CanExecuteSubmit);
      CreateURLCmd = new AsyncCommand(ExecuteSubmitAsyncSite, CanExecuteSubmit);
    }
    #endregion
    #region IAsyncCommands
    public IAsyncCommand AddCustomerCmd { get; private set; }

    public IAsyncCommand CreateAccountCmd { get; private set; }

    public IAsyncCommand CreateURLCmd { get; private set; } 
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
        RegistrationResult registrationResult = await _registrationService.Register(Email, Password);
        this.Email = string.Empty;
        this.Password = string.Empty;
        MessageBox.Show("The account registration was a: " + registrationResult);
      }
      finally
      {
        IsBusy = false;
      }
    }
    public async Task ExecuteSubmitAsyncSite()
    {
      try
      {
        SiteRegistrationResult siteRegistrationResult = await _siteService.CreateSite(Link);
        this.Link = string.Empty;
        MessageBox.Show("The Site registration was a: " + siteRegistrationResult);
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
