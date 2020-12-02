﻿using MvvmCross.ViewModels;
using Starship.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
/// <summary>
/// ViewModel for Handling SideMenu 
/// And Switching between pages on the MainContent
/// </summary>
namespace Starship.ViewModel
{
    /// <summary>
    /// TO DO REFACTOR TO USE STATE PATTERN
    /// </summary>
    public class MainViewModel
    {

        //For Menu Icons - to be implemented - maybe. 
        //ResourceDictionary dict = Application.LoadComponent(new Uri("/Starship;component/asserts/testicons.xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
        public List<MenuItemsData> MenuList
        {
            get
            {
                return new List<MenuItemsData>
                {
                    //MainMenu without SubMenu Button 
                    new MenuItemsData(){MenuText="Home"},
                    new MenuItemsData(){MenuText="Overview"},
                    new MenuItemsData(){MenuText="Add Customer"},
                    new MenuItemsData(){MenuText="Manage Customer"},
                    new MenuItemsData(){MenuText="Log Out"} };
            }
        }
        public class MenuItemsData : MvxViewModel
        {
            private string _menuText;
            //Icon data
            public PathGeometry PathData { get; set; }
           
            public string MenuText
            {
              get { return _menuText; }
              set { SetProperty(ref _menuText, value); }
             }

            public MenuItemsData()
            {
                
                Command = new CommandViewModel(Execute);
            }
            public ICommand Command { get; }

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