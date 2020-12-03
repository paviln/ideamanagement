using IdeaManagement.EF;
using MvvmCross.Platforms.Wpf.Views;
using Starship.ViewModel;
using System;
using System.Windows.Controls;


namespace Starship.View.Pages
{
    /// <summary>
    /// Interaction logic for MangeCustomer.xaml
    /// </summary>
    public partial class ManageCustomer : UserControl
    {
        
        public ManageCustomer()
        {
            InitializeComponent();
            DataContext = new ManageCustomerViewModel();
         }
    
    }
}
