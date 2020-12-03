using IdeaManagement.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Views;
using Starship.HostBuilders;
using System.Windows;

namespace Starship
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = CreateHostBuilder().Build();
        }
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfiguration()
                .AddDbContext()
                .AddServices()
                .AddViewModels();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            IdeaManagementContextFactory contextFactory = _host.Services.GetRequiredService<IdeaManagementContextFactory>();
            using (IdeaManagementDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.EnsureCreatedAsync();
            }
            Window window = new MainWindow();
            window.Show();
            base.OnStartup(e);

        }
    }
}
