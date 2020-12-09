using EskobInnovation.IdeaManagement.WPF.Helpers;
using EskobInnovation.IdeaManagement.WPF.Service;
using EskobInnovation.IdeaManagement.WPF.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Windows;

namespace EskobInnovation.IdeaManagement.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void  OnStartup(StartupEventArgs e)
        {
            //IServiceProvider serviceProvider = CreateServiceProvider();
            //ICustomerService customerService = serviceProvider.GetRequiredService<ICustomerService>();
            //IAccountService accountService = serviceProvider.GetRequiredService<IAccountService>();
            Window window = new MainWindow();
            window.Show();
            base.OnStartup(e);
        }


        //private IServiceProvider CreateServiceProvider()
        //{
        //    IServiceCollection services = new ServiceCollection();

        //    string apiKey = ConfigurationManager.AppSettings.Get("ApiKey") ;
        //    services.AddSingleton<PrepHttpClientFactory>(new PrepHttpClientFactory(apiKey));
        //    services.AddSingleton<ICustomerService, CustomerService>();
        //    services.AddSingleton<IAccountService, AccountService>();
        //    return services.BuildServiceProvider();
        //}
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
