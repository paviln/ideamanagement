using IdeaManagement.Domain.Models;
using IdeaManagement.Domain.Services;
using IdeaManagement.Domain.Services.ValidateServices;
using IdeaManagement.EF;
using IdeaManagement.EF.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Starship.Command;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
/// <summary>
/// Class will be refactored
/// </summary>
namespace Starship.ViewModel
{
    public class AddCustomerViewModel : MvxViewModel
    {
        private readonly IValidateService _validateService;

        private readonly IdeaManagementDbContext _Dbcontext;

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set { SetProperty(ref _customerName, value); }
        }
        public AddCustomerViewModel()
        {
            AddCustomerCmd = new AsyncCommand(ExecuteSubmitAsync, CanExecuteSubmit);
         
        }
        public AddCustomerViewModel(IValidateService validateservice, IdeaManagementDbContext dbContext)
        {
            _validateService = validateservice;
            _Dbcontext = dbContext;

        }
 
        public IAsyncCommand AddCustomerCmd { get; private set; }

        private async Task ExecuteSubmitAsync()
        {
            try
            {
                IsBusy = true;
                CustomerAddResult customerAddResult = await _validateService.AddCustomer(CustomerName);
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
