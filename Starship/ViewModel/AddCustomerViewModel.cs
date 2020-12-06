using MvvmCross.ViewModels;
using Starship.Command;
using System.Threading.Tasks;
using Starship.Service;
/// <summary>
/// 
/// </summary>
namespace Starship.ViewModel
{
    public class AddCustomerViewModel : MvxViewModel
    {
        private readonly ICustomerService _customerService;
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
        #endregion
        //Constructor Injection - dependency injection - (IoC)
        public AddCustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public AddCustomerViewModel()
        {
            _customerService = new CustomerService();
            AddCustomerCmd = new AsyncCommand(ExecuteSubmitAsync, CanExecuteSubmit);
        }
        public IAsyncCommand AddCustomerCmd { get; private set; }

        public async Task ExecuteSubmitAsync()
        {
            try
            {
               // CustomerService service = new CustomerService();
                var cust = await _customerService.CreateCustomerAsync(CompanyName);
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
