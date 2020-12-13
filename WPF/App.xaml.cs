using EskobInnovation.IdeaManagement.WPF.View;
using EskobInnovation.IdeaManagement.WPF.ViewModel;
using System.Windows;

namespace EskobInnovation.IdeaManagement.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    private readonly ManageCustomerViewModel _manageCustomerViewModel;
    public App(ManageCustomerViewModel manageCustomerViewModel)
    {
      _manageCustomerViewModel = manageCustomerViewModel;
    }
    public App()
    {
      _manageCustomerViewModel = new ManageCustomerViewModel();


    }
    protected override void OnStartup(StartupEventArgs e)
    {
      _manageCustomerViewModel.FillDataGrid();

      Window window = new MainWindow();
          window.Show();
          base.OnStartup(e);
         }
    protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
