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

        private void CustomersDG_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {

        }

        private void CustomersDG_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {

        }
    }
}
