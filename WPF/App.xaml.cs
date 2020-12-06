using Microsoft.Extensions.Hosting;
using System.Windows;

namespace EskobInnovation.IdeaManagement.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new MainWindow();
            window.Show();
            base.OnStartup(e);

        }
        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
