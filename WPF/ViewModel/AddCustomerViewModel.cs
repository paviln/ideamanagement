using MvvmCross.ViewModels;
using EskobInnovation.IdeaManagement.WPF.Command;
using System.Threading.Tasks;
using EskobInnovation.IdeaManagement.WPF.Service;
using System.Windows;
using Microsoft.AspNet.Identity;
/// <summary>
/// 
/// </summary>
namespace EskobInnovation.IdeaManagement.WPF.ViewModel
{
    public class AddCustomerViewModel : MvxViewModel
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountService _accountService;

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
        #endregion
        //Constructor Injection - dependency injection - (IoC)
        public AddCustomerViewModel(ICustomerService customerService, IAccountService accountService)
        {
            _customerService = customerService;
            _accountService = accountService;

        }
        public AddCustomerViewModel()
        {
            _accountService = new AccountService();
            _customerService = new CustomerService();
            AddCustomerCmd = new AsyncCommand(ExecuteSubmitAsyncCustomer, CanExecuteSubmit);
            CreateAccountCmd = new AsyncCommand(ExecuteSubmitAsyncAccount, CanExecuteSubmit);
        }
        public IAsyncCommand AddCustomerCmd { get; private set; }

        public IAsyncCommand CreateAccountCmd { get; private set; }

        public async Task ExecuteSubmitAsyncCustomer()
        {
            try
            {
                var cust = await _customerService.CreateCustomerAsync(CompanyName);
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




        private bool CanExecuteSubmit()
        {
            return !IsBusy;
        }
    }
}
