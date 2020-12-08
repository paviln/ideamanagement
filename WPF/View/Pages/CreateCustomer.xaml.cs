using EskobInnovation.IdeaManagement.WPF.ViewModel;
using System.Windows.Controls;

namespace EskobInnovation.IdeaManagement.WPF.View.Pages
{
    /// <summary>
    /// Interaction logic for AddCustomer.xaml
    /// </summary>

    public partial class CreateCustomer : UserControl
    {
        public CreateCustomer()
        {
            InitializeComponent();
            DataContext = new AddCustomerViewModel();
        }

    }
}
