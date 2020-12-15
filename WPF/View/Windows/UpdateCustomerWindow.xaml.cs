using System.Windows;
using EskobInnovation.IdeaManagement.WPF.ViewModel;

namespace EskobInnovation.IdeaManagement.WPF.View.Windows
{
  /// <summary>
  /// Interaction logic for UpdateCustomerWindow.xaml
  /// </summary>
  public partial class UpdateCustomerWindow : Window
  {
    public UpdateCustomerWindow()
    {
      InitializeComponent();
      DataContext = new UpdateCustomerViewModel();
    }
  }
}
