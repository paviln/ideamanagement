using IdeaManagement.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starship.HostBuilders
{
    public static class DbContextHostBuilderExtension
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((c, s) =>
            {
                string connectionString = c.Configuration.GetConnectionString("sqlite");
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);
                s.AddDbContext<IdeaManagementDbContext>(configureDbContext);
                s.AddSingleton<IdeaManagementContextFactory>(new IdeaManagementContextFactory(configureDbContext));

            });
                return host;
        }
    }
}
