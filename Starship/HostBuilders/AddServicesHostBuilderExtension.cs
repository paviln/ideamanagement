using IdeaManagement.Domain.Services;
using IdeaManagement.EF.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using IdeaManagement.Domain.Models;
using IdeaManagement.Domain.Services.ValidateServices;

namespace Starship.HostBuilders
{
    public static class AddServicesHostBuilderExtension
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(s =>
            {
                s.AddSingleton<ICustomerService, CustomerDataService>();
                s.AddSingleton<IDataService<Customer>, CustomerDataService>();
                s.AddSingleton<IValidateService, ValidateService>();
            });
            return host;
        }

    }
}
