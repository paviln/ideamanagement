using IdeaManagement.Domain.Models;
using IdeaManagement.Domain.Services;
using IdeaManagement.EF;
using IdeaManagement.EF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Starship.HostBuilders;
using Starship.ViewModel;
using System;
using System.Windows;
namespace Starship
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ///Refactor from sqlserver to sqllite 
        
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
        
        #region Overrides of Application
            /// <summary>
            /// 
            /// </summary>
            /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            IdeaManagementContextFactory contextFactory = _host.Services.GetRequiredService<IdeaManagementContextFactory>();
            using (IdeaManagementDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }

            Window window = new MainWindow();
            window.Show();
            base.OnStartup(e);

         }
        #endregion
    }
}
