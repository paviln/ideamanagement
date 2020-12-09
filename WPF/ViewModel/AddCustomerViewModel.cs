using MvvmCross.ViewModels;
using EskobInnovation.IdeaManagement.WPF.Command;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.WPF.Service;
using EskobInnovation.IdeaManagement.WPF.Service.SiteServices;
/// <summary>
/// 
/// </summary>
namespace EskobInnovation.IdeaManagement.WPF.ViewModel
{
  public class AddCustomerViewModel : MvxViewModel
  {
    private readonly ICustomerService _customerService;
    private readonly IAccountService _accountService;
    private readonly ISiteService _siteService;
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
    //Constructor Injection - dependency injection - (IoC)
    public AddCustomerViewModel(ICustomerService customerService, IAccountService accountService, ISiteService siteService)
    {
      _customerService = customerService;
      _accountService = accountService;
      _siteService = siteService;

    }
    public AddCustomerViewModel()
    {
      _accountService = new AccountService();
      _customerService = new CustomerService();
      _siteService = new SiteService();
      AddCustomerCmd = new AsyncCommand(ExecuteSubmitAsyncCustomer, CanExecuteSubmit);
      CreateAccountCmd = new AsyncCommand(ExecuteSubmitAsyncAccount, CanExecuteSubmit);
    }
    public IAsyncCommand AddCustomerCmd { get; private set; }

    public IAsyncCommand CreateAccountCmd { get; private set; }

    public IAsyncCommand CreateURLCmd { get; private set; }

    #region Async Executes
    public async Task ExecuteSubmitAsyncCustomer()
    {
      try
      {

        var cust = await _customerService.CreateCustomerAsync(CompanyName, StreetAddresse, ZipCode, ContactPerson);
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
        var acc = await _accountService.CreateApplicationUserAccount(Email, Password);
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
        var _site = await _siteService.CreateLinkAsync(Link);
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
