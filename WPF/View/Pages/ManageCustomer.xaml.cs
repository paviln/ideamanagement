using EskobInnovation.IdeaManagement.WPF.ViewModel;
using System;
using System.Windows.Controls;


namespace EskobInnovation.IdeaManagement.WPF.View.Pages
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
