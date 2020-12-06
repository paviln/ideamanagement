using MvvmCross.ViewModels;
using Starship.Command;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
/// <summary>
/// ViewModel for Handling SideMenu 
/// And Switching between pages on the MainContent
/// </summary>
namespace Starship.ViewModel
{
    /// <summary>
    /// TO DO REFACTOR TO USE STATE PATTERN
    /// </summary>
    public class MainViewModel : MvxViewModel
    {
        public List<MenuItemsData> MenuList
        {
            get
            {
                return new List<MenuItemsData>
                {
                    //MainMenu without SubMenu Button 
                    new MenuItemsData(){MenuText="Home"},                    
                    new MenuItemsData(){MenuText="Add Customer"},
                    new MenuItemsData(){MenuText="Manage Customer"},
                    new MenuItemsData(){MenuText="Create Account"} };
            }
        }
        public class MenuItemsData : MvxViewModel
        {
            private bool _isBusy;

            public bool IsBusy
            {
                get { return _isBusy; }
                set { SetProperty(ref _isBusy, value); }
            }
            private string _menuText;
          
            public string MenuText
            {
              get { return _menuText; }
              set { SetProperty(ref _menuText, value); }
             }
            public MenuItemsData()
            {
                NavigatePageCmd = new AsyncCommand(ExecuteSubmitAsync, CanExecuteSubmit);
            }
            public IAsyncCommand NavigatePageCmd { get; private set; }

            private async Task ExecuteSubmitAsync()
            {
                try
                {
                    IsBusy = true;
                    Execute();
                    //CustomerAddResult customerAddResult = await _validateService.AddCustomer(CustomerName);

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


            private void Execute()
            {
                string MT = MenuText.Replace(" ", string.Empty);
                if (!string.IsNullOrEmpty(MT))
                    NavigateToPage(MT);
            }
            private void NavigateToPage(string Menu)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "View/Pages/", Menu, ".xaml"), UriKind.RelativeOrAbsolute));
                    }
                }
            }
        }
    }
}
