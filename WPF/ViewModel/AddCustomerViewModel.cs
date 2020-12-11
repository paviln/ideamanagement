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
    private string _streetAddresse;

    public string StreetAddresse
    {
      get { return _streetAddresse; }
      set { SetProperty(ref _streetAddresse, value); }
    }
    private string _zipCode;

    public string ZipCode
    {
      get { return _zipCode; }
      set { SetProperty(ref _zipCode, value); }
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

    public MessageViewModel ErrorMessageViewModel { get; }

    public string ErrorMessage
    {
      set => ErrorMessageViewModel.Message = value;
    }

    public MessageViewModel StatusMessageViewModel { get; }

    public string StatusMessage
    {
      set => StatusMessageViewModel.Message = value;
    }
    #region Async Executes
    public async Task ExecuteSubmitAsyncCustomer()
    {
      try
      {
        RegistrationResultCustomer registrationResult = await _manageCustomerService.CreateCustomer(CompanyName, StreetAddresse, ZipCode, ContactPerson);
        this.CompanyName = string.Empty;
        this.StreetAddresse = string.Empty;
        this.ZipCode = string.Empty;
        this.ContactPerson = string.Empty;

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
        SiteRegistration siteRegistrationResult = await _siteService.CreateSite(Link);
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
