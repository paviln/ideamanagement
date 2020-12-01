using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Starship.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starship.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(s =>
            {
              
                s.AddSingleton<AddCustomerViewModel>();
                

            });
            return host;
        }

       
    }
}
