using MvvmCross.ViewModels;
using EskobInnovation.IdeaManagement.WPF.Command;
using System;
using System.Collections.Generic;
using System.Windows;
using EskobInnovation.IdeaManagement.WPF.View;
using System.Windows.Input;
/// <summary>
/// ViewModel for Handling SideMenu 
/// And Switching between pages on the MainContent
/// </summary>
namespace EskobInnovation.IdeaManagement.WPF.ViewModel
{
  public class MainViewModel
  {
    public List<MenuItemsData> MenuList
    {
      get
      {
        return new List<MenuItemsData>
        {
          new MenuItemsData(){MenuText="Registration"},
          new MenuItemsData(){MenuText="Manage Customer"}
        };
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
        ChangePageCommand = new SyncCommandBase(Execute);
      }
      public ICommand ChangePageCommand { get; set; }
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
